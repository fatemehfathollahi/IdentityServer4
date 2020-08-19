
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Plus.Infrastructure.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Options;
using System;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess 
/// <summary>
{   /// Extension methods to add EF database support to IdentityServer.
    /// </summary>
    public static class IdentityServerBuilderExtensions
    {
      
        public static IServiceCollection AddConfigurationDbContext(this IServiceCollection services,
            Action<IdentityConfigurationStoreOptions> storeOptionsAction = null)
        {
            return services.AddConfigurationDbContext<IdentityConfigurationDbContext>(storeOptionsAction);
        }

        public static IServiceCollection AddConfigurationDbContext<TContext>(this IServiceCollection services,
        Action<IdentityConfigurationStoreOptions> storeOptionsAction = null)
        where TContext : DbContext, IIdentityConfigurationDbContext
        {
            var options = new IdentityConfigurationStoreOptions();

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
            services.AddScoped<IIdentityConfigurationDbContext, TContext>();

            return services;
        }


        public static IServiceCollection AddOperationalDbContext(this IServiceCollection services,
            Action<IdentityOperationalStoreOptions> storeOptionsAction = null)
        {
            return services.AddOperationalDbContext<IdentityPersistedGrantDbContext>(storeOptionsAction);
        }


        public static IServiceCollection AddOperationalDbContext<TContext>(this IServiceCollection services,
            Action<IdentityOperationalStoreOptions> storeOptionsAction = null)
            where TContext : DbContext, IIdentityPersistedGrantDbContext
        {
            var storeOptions = new IdentityOperationalStoreOptions();
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

            services.AddScoped<IIdentityPersistedGrantDbContext, TContext>();
            // services.AddSingleton<TokenCleanup>();

            return services;
        }



        //public static IServiceCollection AddOperationalStoreNotification<T>(this IServiceCollection services)
        //   where T : class, IOperationalStoreNotification
        //{
        //    services.AddTransient<IOperationalStoreNotification, T>();
        //    return services;
        //}


        //public static IIdentityServerBuilder AddEFConfigurationStore<TContext>(
        //     this IIdentityServerBuilder builder)
        //    where TContext : DbContext, IIdentityConfigurationDbContext
        //{
        //    Type typeParameterType = typeof(TContext);
        //  var _domainService =  typeParameterType.GetField("domainService");

        //    string assemblyNamespace = typeof(IdentityServerBuilderExtensions).GetTypeInfo()
        //        .Assembly
        //        .GetName()
        //        .Name;
        //    builder.AddConfigurationStore(options =>
        //    options.ConfigureDbContext = b => b.UseSqlServer(((IDomainService)_domainService).GetDomainInfo().ConnectionString, optionsBuilder =>
        //         optionsBuilder.MigrationsAssembly(assemblyNamespace)));
        //    return builder;
        //}
    }
}
