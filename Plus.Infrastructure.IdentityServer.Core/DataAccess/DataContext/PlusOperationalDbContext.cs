using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.Core.Domain.Service;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{
    public class PlusOperationalDbContext : PersistedGrantDbContext
    {
        private readonly IDomainService domainService;
        public PlusOperationalDbContext(DbContextOptions<PersistedGrantDbContext> options,
            OperationalStoreOptions storeOptions,
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
}
