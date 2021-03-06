using Microsoft.Extensions.DependencyInjection;
using MobeAdmin.DataAccess.Interface;
using MobeAdmin.DataAccess.Interface.AdminDb;
using MobeAdmin.DataAccess.Repository;
using MobeAdmin.DataAccess.Repository.AdminDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess
{
    public static class DependencyInjection
    {
        public static void AddDataAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));
            //foreach (var Type in Assembly.Load("MobeAdmin.DataAccess").GetTypes().Where(c => !c.IsInterface && !c.IsAbstract && c.GetInterfaces().Count() > 0))
            //{
            //    foreach (var ImplementedInterface in Type.GetInterfaces())
            //    {
            //        services.AddTransient(ImplementedInterface, Type);
            //    }
            //}

        }
    }
}
