using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
        public ReqRespLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            Stream originalBody = context.Response.Body;
            try
            {
                await LogRequest(context);

                using (var ms = new MemoryStream())
                {
                    context.Response.Body = ms;

                    await _next(context);

                    LogResponse(context.Response, ms);

                    ms.Position = 0;
                    await ms.CopyToAsync(originalBody);
                }
            }
            catch (Exception ex)
            {
                                
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }

        private async Task LogRequest(HttpContext context)
        {
            var request = context.Request;
            var sr = new StreamReader(request.Body);
            var body = await sr.ReadToEndAsync();
        }

        private void LogResponse(HttpResponse context, MemoryStream ms)
        {

        }

    }

}
