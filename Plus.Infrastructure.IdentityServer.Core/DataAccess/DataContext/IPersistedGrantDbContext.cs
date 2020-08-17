
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext
{
    public interface IPersistedGrantDbContext : IDisposable
    {
       
        DbSet<PlusPersistedGrant> PlusPersistedGrants { get; set; }

        DbSet<PlusDeviceFlowCodes> PlusDeviceFlowCodes { get; set; }
        
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}