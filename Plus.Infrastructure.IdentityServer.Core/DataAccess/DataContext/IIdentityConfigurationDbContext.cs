
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{

    public interface IIdentityConfigurationDbContext : IDisposable
    {
       
        DbSet<Client> Clients { get; set; }

        DbSet<IdentityResource> IdentityResources { get; set; }

        DbSet<ApiResource> ApiResources { get; set; }

       // DbSet<ApiScope> ApiScops { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}