using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Plus.Infrastructure.Core.Domain.Model;
using Plus.Infrastructure.Core.Domain.Service;
using Plus.Infrastructure.Domain.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Configuration;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Plus.Infrastructure.IdentityServer
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDependencyInjection();
            services.AddControllersWithViews();
            services.AddRazorPages();

            var dependencyRegistrars = GetAllClasses<IDependencyRegistrar>().Select(x => Activator.CreateInstance(x) as IDependencyRegistrar);

            foreach (var item in dependencyRegistrars.OrderBy(x => x.Order))
            {
                item.Register(services);
            }

            services.AddHttpContextAccessor();

            services
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<PlusDataContext>()
                .AddUserManager<PlusUserManager>()
                .AddUserStore<PlusUserStore>()
                .AddSignInManager<PlusSignInManager>()
                .AddDefaultTokenProviders();

            services
                .AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                })
               .AddSigningCredential(IdentityServerHelper.GetCertificate2(webHostEnvironment))
               .AddAspNetIdentity<ApplicationUser>()
               .AddConfigurationStore<PlusConfigurationDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => configuration.Bind(Constant.JwtSettingsName, options))
                     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                     {
                         configuration.Bind(Constant.CookieSettingsName, options);

                     });

            services.AddAuthorization();
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
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Use(async (ctx, next) =>
                    {
                        ctx.Request.Path = "";
                        await next();
                    });
                });
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                     Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/lib")),
                RequestPath = new PathString("/wwwroot/lib")
            });

            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "login",
                    pattern: "{controller=Account}/{action=Login}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }


        private List<Type> GetAllClasses<TInterface>()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                 .Where(x => typeof(TInterface).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x).ToList();
        }
    }
}
