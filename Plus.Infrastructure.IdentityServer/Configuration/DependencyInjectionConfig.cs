using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.Domain.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.Service;

namespace Plus.Infrastructure.IdentityServer.Configuration
{
    public static class DependencyInjectionConfig
    {
        internal static void RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ConfigurationDbContext>();
            services.AddTransient<PersistedGrantDbContext>();
            services.AddTransient<OperationalStoreOptions>();

            services.AddTransient<DbContextOptions<ConfigurationDbContext>>();
            services.AddTransient<DbContextOptions<PersistedGrantDbContext>>();



            services.AddDbContext<PlusDataContext>();
            services.AddDbContext<PlusConfigurationDbContext>();
            services.AddDbContext<PlusOperationalDbContext>();


            services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();
            services.AddScoped<IPlusClientClaimRepository, PlusClientClaimRepository>();
            services.AddScoped<IPlusClientCorsOriginRepository, PlusClientCorsOriginRepository>();
            services.AddScoped<IPlusClientGrantTypeRepository, PlusClientGrantTypeRepository>();
            services.AddScoped<IPlusClientIdPRestrictionRepository, PlusClientIdPRestrictionRepository>();
            services.AddScoped<IPlusClientPostLogoutRedirectUriRepository, PlusClientPostLogoutRedirectUriRepository>();
            services.AddScoped<IPlusClientPropertyRepository, PlusClientPropertyRepository>();
            services.AddScoped<IPlusClientRedirectUriRepository, PlusClientRedirectUriRepository>();
            services.AddScoped<IPlusClientScopeRepository, PlusClientScopeRepository>();
            services.AddScoped<IPlusClientSecretRepository, PlusClientSecretRepository>();
            services.AddScoped<IPlusClientRepository, PlusClientRepository>();
            services.AddScoped<IPlusClientService, PlusClientService>();
            services.AddScoped<IPlusIdentityResourceRepository, PlusIdentityResourceRepository>();
            services.AddScoped<IPlusIdentityResourceService, PlusIdentityResourceService>();
            services.AddScoped<IPlusApiResourceRepository, PlusApiResourceRepository>();
            services.AddScoped<IPlusApiResourceService, PlusApiResourceService>();
            services.AddScoped<IPlusApiResourceScopeRepository, PlusApiResourceScopeRepository>();
            services.AddScoped<IPlusApiResourceSecretRepository, PlusApiResourceSecretRepository>();
            services.AddScoped<IPlusApiResourceClaimRepository, PlusApiResourceClaimRepository>();
            services.AddScoped<IPlusApiResourcePropertyRepository, PlusApiResourcePropertyRepository>();

        }
    }
}
