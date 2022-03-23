using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MobeAdmin.Core.Middleware;
using MobeAdmin.Core.Services;
using MobeAdmin.DataAccess;
using MobeAdmin.DataAccess.DbCore.Base;
using MobeAdmin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MobeAdmin
{
    public class Startup
    {
        private IServiceCollection _services;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var ConnectionDict = new Dictionary<EnumConnectionName, string>
            {
                { EnumConnectionName.Master, this.Configuration.GetConnectionString("Master") },
                { EnumConnectionName.Slave, this.Configuration.GetConnectionString("Slave") }
            };

            //Init SQL �D�q�s�u [follow up] �i��i�H���K�a�J Db �`�� Ex
            services.AddSingleton<IDictionary<EnumConnectionName, string>>(ConnectionDict);
            services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();

            //Init AutoMappper 
            services.AddAutoMapperEntity();
            //Init DataAccessLayer ���ݭn���� Interface
            services.AddDataAccessLayer();
            //Init ServiceLayer ���Ҧ��� Interface
            services.AddServiceLayer();

            services.AddControllersWithViews();

            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                //�u�|�b Development ���ͮġA��� Exception �T��
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");

                app.UseExceptionHandler();
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                // Tips: Hsts(HTTP Strict Transport Security Protocol)
                // ���s�������즹���Y�ɡA�N�j��H HTTPS �b�o�Ӻ��줤�i��Ҧ��T���ǻ�
                // HSTS �b���Τ��ݭn�ܤ֤@���� HTTPS �~��إ� Protocol
                app.UseHsts();
            }

            app.UseListedService(_services);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
