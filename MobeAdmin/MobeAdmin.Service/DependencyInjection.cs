using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {

            foreach (var Type in Assembly.Load("MobeAdmin.Service").GetTypes().Where(c => !c.IsInterface && !c.IsAbstract && c.GetInterfaces().Count() > 0))
            {
                foreach (var ImplementedInterface in Type.GetInterfaces())
                {
                    services.AddTransient(ImplementedInterface, Type);
                }
            }

        }
    }
}
