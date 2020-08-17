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
    public class ConfigurationDbContext : ConfigurationDbContext<ConfigurationDbContext>
    {
        private readonly IDomainService domainService;
        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options,
            ConfigurationStoreOptions storeOptions, IDomainService domainService)
            : base(options, storeOptions)
        {
            this.domainService = domainService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(domainService.GetDomainInfo().ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }

    public class ConfigurationDbContext<TContext> : DbContext, IConfigurationDbContext
    where TContext : DbContext, IConfigurationDbContext
    {
        private readonly ConfigurationStoreOptions storeOptions;
      

        public ConfigurationDbContext(DbContextOptions<TContext> options, ConfigurationStoreOptions storeOptions)

      : base(options)
        {
            this.storeOptions = storeOptions ?? throw new ArgumentNullException(nameof(storeOptions));

        }


        public DbSet<PlusClient> PlusClients { get; set; }

        public DbSet<PlusIdentityResource> PlusIdentityResources { get; set; }

        public DbSet<PlusApiResource> PlusApiResources { get; set; }
        DbSet<PlusClient> IConfigurationDbContext.PlusClients { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<PlusIdentityResource> IConfigurationDbContext.PlusIdentityResources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DbSet<PlusApiResource> IConfigurationDbContext.PlusApiResources { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
