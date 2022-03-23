using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Core.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void UseExceptionHandlerExtension(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionFeature?.Error != null)
                    {

                    }
                },
                ExceptionHandlingPath = "/Home/Error"
            }) ;
        }
    }
}
