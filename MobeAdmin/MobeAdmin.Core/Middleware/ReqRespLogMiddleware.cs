using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Core.Middleware
{
    public class ReqRespLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ReqRespLogMiddleware> _logger;
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager;
        public ReqRespLogMiddleware(RequestDelegate next, ILogger<ReqRespLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _recyclableMemoryStreamManager = new RecyclableMemoryStreamManager();
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            Stream originalBody = context.Response.Body;
            try
            {
                await RequestLogger(context.Request);


                var originalBodyStream = context.Response.Body;
                await using var responseBody = _recyclableMemoryStreamManager.GetStream();
                context.Response.Body = responseBody;

                await _next(context);

                context.Response.Body.Seek(0, SeekOrigin.Begin);
                var responseBodyTxt = await new StreamReader(context.Response.Body).ReadToEndAsync();
                context.Response.Body.Seek(0, SeekOrigin.Begin);
                await responseBody.CopyToAsync(originalBodyStream);

                _logger.LogInformation(
              $"Schema:{context.Request.Scheme} \n" +
              $"Host: {context.Request.Host.ToUriComponent()} \n" +
              $"Path: {context.Request.Path} \n" +
              $"QueryString: {context.Request.QueryString} \n" +
              $"ResponseHeader: {GetHeaders(context.Response.Headers)} \n" +
              $"ResponseStatus: {context.Response.StatusCode} \n");

            }
            catch (Exception e)
            {

            }
            finally
            {
                
            }
        }

        private async Task RequestLogger(HttpRequest httpRequest)
        {
            httpRequest.EnableBuffering();
            await using var requestStream = _recyclableMemoryStreamManager.GetStream();
            await httpRequest.Body.CopyToAsync(requestStream);

            _logger.LogInformation($"Http Request Information:{Environment.NewLine} \n" +
                       $"Schema:{httpRequest.Scheme} \n" +
                       $"Host: {httpRequest.Host} \n" +
                       $"Path: {httpRequest.Path} \n" +
                       $"ResponseHeader: {GetHeaders(httpRequest.Headers)} \n" +
                       $"QueryString: {httpRequest.QueryString} \n" +
                       $"Request Body: {ReadStreamInChunks(requestStream)} \n");
            httpRequest.Body.Position = 0;
        }

        private static string GetHeaders(IHeaderDictionary headers)
        {
            var headerStr = new StringBuilder();
            foreach (var header in headers)
            {
                headerStr.Append($"{header.Key}: {header.Value}\n");
            }

            return headerStr.ToString();
        }

        private static string ReadStreamInChunks(Stream stream)
        {
            const int readChunkBufferLength = 4096;
            stream.Seek(0, SeekOrigin.Begin);
            using var textWriter = new StringWriter();
            using var reader = new StreamReader(stream);
            var readChunk = new char[readChunkBufferLength];
            int readChunkLength;
            do
            {
                readChunkLength = reader.ReadBlock(readChunk,
                                                   0,
                                                   readChunkBufferLength);
                textWriter.Write(readChunk, 0, readChunkLength);
            } while (readChunkLength > 0);
            return textWriter.ToString();
        }

        private async Task ResponseLogger(HttpResponse httpResponse, MemoryStream ms)
        {
     
        }
    }
}