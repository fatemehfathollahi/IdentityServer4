using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Plus.Infrastructure.IdentityServer.Classes;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Plus.Infrastructure.IdentityServer
{
    internal static class IdentityServerHelper
    {
        internal static X509Certificate2 GetCertificate2(IWebHostEnvironment webHostEnvironment)
        {
            return new X509Certificate2(Path.Combine(webHostEnvironment.ContentRootPath, Constant.CertificateDirectoryName, Constant.IdentityServer4CertificateFileName), Constant.IdentityServer4CertificatePassword);

        }

        internal static void InitializeDatabase(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PlusOperationalDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<PlusConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    if (env.IsDevelopment())
                    {
                        foreach (var client in Config.Clients)
                        {
                           context.Clients.Add(client.ToEntity());
                        }
                        context.SaveChanges();
                    }
                }

                if (!context.IdentityResources.Any())
                {
                    if (env.IsDevelopment())
                    {
                        foreach (var resource in Config.IdentityResources)
                        {
                           context.IdentityResources.Add(resource.ToEntity());
                        }
                        context.SaveChanges();
                    }
                }

                if (!context.ApiResources.Any())
                {
                    if (env.IsDevelopment())
                    {
                        foreach (var resource in Config.ApiScopes)
                        {
                            context.ApiScopes.Add(resource.ToEntity());
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
