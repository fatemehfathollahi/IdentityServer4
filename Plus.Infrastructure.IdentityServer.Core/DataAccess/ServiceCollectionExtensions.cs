
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Options;
using System;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess // DL.Data.ConfigurationStore.EfCore.Extentions//
/// <summary>
{   /// Extension methods to add EF database support to IdentityServer.
    /// </summary>
    public static class IdentityServerBuilderExtensions
    {
        public static IServiceCollection AddConfigurationDbContext(this IServiceCollection services,
            Action<ConfigurationStoreOptions> storeOptionsAction = null)
        {
            return services.AddConfigurationDbContext<ConfigurationDbContext>(storeOptionsAction);
        }


        public static IServiceCollection AddConfigurationDbContext<TContext>(this IServiceCollection services,
        Action<ConfigurationStoreOptions> storeOptionsAction = null)
        where TContext : DbContext, IConfigurationDbContext
        {
            var options = new ConfigurationStoreOptions();
            services.AddSingleton(options);
            storeOptionsAction?.Invoke(options);

            if (options.ResolveDbContextOptions != null)
            {
                services.AddDbContext<TContext>(options.ResolveDbContextOptions);
            }
            else
            {
                services.AddDbContext<TContext>(dbCtxBuilder =>
                {
                    options.ConfigureDbContext?.Invoke(dbCtxBuilder);
                });
            }
            services.AddScoped<IConfigurationDbContext, TContext>();

            return services;
        }


        public static IServiceCollection AddOperationalDbContext(this IServiceCollection services,
            Action<OperationalStoreOptions> storeOptionsAction = null)
        {
            return services.AddOperationalDbContext<PersistedGrantDbContext>(storeOptionsAction);
        }


        public static IServiceCollection AddOperationalDbContext<TContext>(this IServiceCollection services,
            Action<OperationalStoreOptions> storeOptionsAction = null)
            where TContext : DbContext, IPersistedGrantDbContext
        {
            var storeOptions = new OperationalStoreOptions();
            services.AddSingleton(storeOptions);
            storeOptionsAction?.Invoke(storeOptions);

            if (storeOptions.ResolveDbContextOptions != null)
            {
                services.AddDbContext<TContext>(storeOptions.ResolveDbContextOptions);
            }
            else
            {
                services.AddDbContext<TContext>(dbCtxBuilder =>
                {
                    storeOptions.ConfigureDbContext?.Invoke(dbCtxBuilder);
                });
            }

            services.AddScoped<IPersistedGrantDbContext, TContext>();
            // services.AddSingleton<TokenCleanup>();

            return services;
        }


        //public static IServiceCollection AddOperationalStoreNotification<T>(this IServiceCollection services)
        //   where T : class, IOperationalStoreNotification
        //{
        //    services.AddTransient<IOperationalStoreNotification, T>();
        //    return services;
        //}


        //public static IIdentityServerBuilder AddEFConfigurationStore(
        //     this IIdentityServerBuilder builder, IDomainService domainService)
        //{
        //    domainService = domainService;
        //    string assemblyNamespace = typeof(Core.DataAccess.IdentityServerBuilderExtensions).GetTypeInfo()
        //        .Assembly
        //        .GetName()
        //        .Name;
        //    builder.AddConfigurationStore(options =>
        //    options.ConfigureDbContext = b => b.UseSqlServer(domainService.GetDomainInfo().ConnectionString, optionsBuilder =>
        //         optionsBuilder.MigrationsAssembly(assemblyNamespace)));
        //    return builder;
        //}



        //public static IdentityServerBuilderExtensions AddEfConfigurationStore<TContext>(
        //    this IdentityServerBuilderExtensions builder,
        //    Action<Core.Options.ConfigurationStoreOptions> storeOptionsAction = null)
        //    where TContext : DbContext, Core.DataAccess.DataContext.IConfigurationDbContext
        //{
        //    builder.AddConfigurationDbContext<TContext>(storeOptionsAction);

        //    //builder.AddClientStore<ClientStore>();
        //    //builder.AddResourceStore<ResourceStore>();
        //    //builder.AddCorsPolicyService<CorsPolicyService>();

        //    return builder;
        //}

    }
}
