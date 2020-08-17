
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{

    public interface IConfigurationDbContext : IDisposable
    {
        DbSet<PlusClient> PlusClients { get; set; }

        DbSet<PlusIdentityResource> PlusIdentityResources { get; set; }

        DbSet<PlusApiResource> PlusApiResources { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}