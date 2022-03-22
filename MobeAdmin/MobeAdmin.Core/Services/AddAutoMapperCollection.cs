using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.Core.Services
{
    public static class AddAutoMapperCollection
    {
        public static void AddAutoMapperEntity(this IServiceCollection services)
        {
            //判斷 Serviec 主體
            if (services == null) throw new ArgumentNullException(nameof(services));
            // 載入 AddAutoMapper 與相關設定
            // 指定載入 MobeAdmin.Domain 整顆 Assemblies, AddAutoMapper 會反射找出所有 Profile
            //var test1 = AppDomain.CurrentDomain.GetAssemblies();
            //var test2 = AppDomain.CurrentDomain.Load("MobeAdmin.Domain");
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(AppDomain.CurrentDomain.Load("MobeAdmin.Domain"));
        }
    }
}
