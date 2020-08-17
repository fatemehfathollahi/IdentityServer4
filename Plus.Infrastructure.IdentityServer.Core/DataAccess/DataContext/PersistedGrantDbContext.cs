using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Extensions;
using Plus.Infrastructure.IdentityServer.Core.Options;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{
    public class PersistedGrantDbContext : PersistedGrantDbContext<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext(DbContextOptions<PersistedGrantDbContext> options,
            OperationalStoreOptions storeOptions)
            : base(options, storeOptions)
        {
        }
    }

    public class PersistedGrantDbContext<TContext> : DbContext, IPersistedGrantDbContext
        where TContext : DbContext, IPersistedGrantDbContext
    {
        private readonly OperationalStoreOptions storeOptions;


        public PersistedGrantDbContext(DbContextOptions options, OperationalStoreOptions storeOptions)
            : base(options)
        {
            if (storeOptions == null) throw new ArgumentNullException(nameof(storeOptions));
            this.storeOptions = storeOptions;
        }

        public DbSet<PlusPersistedGrant> PlusPersistedGrants { get; set; }

        public DbSet<PlusDeviceFlowCodes> PlusDeviceFlowCodes { get; set; }

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
