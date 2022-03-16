using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
        }

        private void LogRequest(HttpContext context)
        { 
        
        }

        private void LogResponse(HttpContext context)
        {

        }

    }

}
