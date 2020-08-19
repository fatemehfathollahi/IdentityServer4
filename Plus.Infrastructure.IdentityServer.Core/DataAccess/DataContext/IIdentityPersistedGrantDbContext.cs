
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{
    public interface IIdentityPersistedGrantDbContext : IDisposable
    {
       
        DbSet<PersistedGrant> PersistedGrants { get; set; }

        DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
        
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}