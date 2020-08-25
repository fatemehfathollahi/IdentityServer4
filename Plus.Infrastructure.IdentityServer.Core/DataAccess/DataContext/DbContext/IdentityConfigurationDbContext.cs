using System;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Extensions;
using Plus.Infrastructure.IdentityServer.Core.Options;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{
    public class IdentityConfigurationDbContext : IdentityConfigurationDbContext<IdentityConfigurationDbContext>
    {
        public IdentityConfigurationDbContext(DbContextOptions<IdentityConfigurationDbContext> options,
            IdentityConfigurationStoreOptions storeOptions)
            : base(options, storeOptions)
        {

        }

    }

    public class IdentityConfigurationDbContext<TContext> : DbContext, IIdentityConfigurationDbContext
    where TContext : DbContext, IIdentityConfigurationDbContext
    {
        private readonly IdentityConfigurationStoreOptions storeOptions;
      
        public IdentityConfigurationDbContext(DbContextOptions<TContext> options,
            IdentityConfigurationStoreOptions storeOptions)

      : base(options)
        {
            this.storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));
        }


        public DbSet<Domain.Models.Client> Clients { get; set; }

        public DbSet<Domain.Models.IdentityResource> IdentityResources { get; set; }

        public DbSet<Domain.Models.ApiResource> ApiResources { get; set; }

        DbSet<Domain.Models.Client> IIdentityConfigurationDbContext.Clients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<Domain.Models.IdentityResource> IIdentityConfigurationDbContext.IdentityResources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<Domain.Models.ApiResource> IIdentityConfigurationDbContext.ApiResources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

       
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureClientContext(storeOptions);
            modelBuilder.ConfigureResourcesContext(storeOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}
