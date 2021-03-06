using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Plus.Infrastructure.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Plus.Infrastructure.IdentityServerClient
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
            services.AddHttpContextAccessor();

            var dependencyRegistrars = GetAllClasses<IDependencyRegistrar>().Select(x => Activator.CreateInstance(x) as IDependencyRegistrar);

            foreach (var item in dependencyRegistrars.OrderBy(x => x.Order))
            {
                item.Register(services);
            }

            services.AddSingleton<IPostConfigureOptions<OpenIdConnectOptions>, PlusOpenIdConnectPostConfigureOptions>();

            services.AddControllersWithViews();

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddOpenIdConnect();


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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}").RequireAuthorization();
            });
        }

        public List<Type> GetAllClasses<TInterface>()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Plus.Infrastructure.Core")).SelectMany(x => x.GetTypes())
                 .Where(x => typeof(TInterface).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x).ToList();
        }
    }
}
