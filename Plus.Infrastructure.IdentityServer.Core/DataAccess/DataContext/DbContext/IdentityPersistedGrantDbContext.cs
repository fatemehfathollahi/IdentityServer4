using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Extensions;
using Plus.Infrastructure.IdentityServer.Core.Options;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{
    public class IdentityPersistedGrantDbContext : IdentityPersistedGrantDbContext<IdentityPersistedGrantDbContext>
    {
        private readonly IDomainService domainService;
        public IdentityPersistedGrantDbContext(DbContextOptions<IdentityPersistedGrantDbContext> options,
            IdentityOperationalStoreOptions storeOptions,
            IDomainService domainService)
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

    public class IdentityPersistedGrantDbContext<TContext> : DbContext, IIdentityPersistedGrantDbContext
        where TContext : DbContext, IIdentityPersistedGrantDbContext
    {
        private readonly IdentityOperationalStoreOptions storeOptions;
        public IdentityPersistedGrantDbContext(DbContextOptions options, IdentityOperationalStoreOptions storeOptions)
            : base(options)
        {
            if (storeOptions == null) throw new ArgumentNullException(nameof(storeOptions));
            this.storeOptions = storeOptions;
        }

        public DbSet<PersistedGrant> PersistedGrants { get; set; }

        public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigurePersistedGrantContext(storeOptions);

            base.OnModelCreating(modelBuilder);
        }
    }
}
