using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AskAMech.Core.Gateways.Repositories;
using AskAMech.Core.UseCases;
using AskAMech.Core.UseCases.Interfaces;
using AskAMech.Infrastructure.Data.Helpers;
using AskAMech.Infrastructure.Data.Mapping;
using AskAMech.Infrastructure.Data.Repositories;
using AskAMech.Web.Presenters;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AskAMech.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(c => c.AddProfile<MappingProfiles>(), typeof(Startup));
            
            var connectionString = new SqlHelper(Configuration.GetConnectionString("AskAMechDbConnectionString"));
            services.AddSingleton(connectionString);

            services.AddTransient<IModelPresenter, ModelPresenter>();
            services.AddTransient<ILoginUseCase, LoginUseCase>();
            services.AddTransient<IRegisterUseCase, RegisterUseCase>();
            services.AddTransient<IUserDashboardUseCase, UserDashboardUseCase>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IUserDashboardRepository, UserDashboardRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
