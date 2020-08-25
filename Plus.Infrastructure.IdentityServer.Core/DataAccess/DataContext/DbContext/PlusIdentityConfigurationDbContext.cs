//using IdentityServer4.EntityFramework.DbContexts;
//using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Extensions;
using Plus.Infrastructure.IdentityServer.Core.Options;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{
    public class PlusIdentityConfigurationDbContext :IdentityConfigurationDbContext 
    {
        private readonly IDomainService domainService;

        public PlusIdentityConfigurationDbContext(DbContextOptions<IdentityConfigurationDbContext> options,
            IdentityConfigurationStoreOptions storeOptions,
            IDomainService domainService)
            : base(options, storeOptions)
        {
            this.domainService = domainService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data source=.;Initial Catalog=Payamgostar3;User ID=payamgostardba;Password=12345";//Configuration.GetConnectionString("db");

            optionsBuilder.UseSqlServer(connectionString);//(domainService.GetDomainInfo().ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
       
    }
}
