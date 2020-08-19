
using System;
using Microsoft.EntityFrameworkCore;

namespace Plus.Infrastructure.IdentityServer.Core.Options
{
   
    public class IdentityOperationalStoreOptions
    {
      
        public Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }

        public Action<IServiceProvider, DbContextOptionsBuilder> ResolveDbContextOptions { get; set; }

        public string DefaultSchema { get; set; } = null;

        public IdentityTableConfiguration ApiPersistedGrants { get; set; } = new IdentityTableConfiguration("ApiPersistedGrants");
   
        public IdentityTableConfiguration DeviceFlowCodes { get; set; } = new IdentityTableConfiguration("DeviceFlowCodes");
       
        public bool EnableTokenCleanup { get; set; } = false;

        public int TokenCleanupInterval { get; set; } = 3600;

        public int TokenCleanupBatchSize { get; set; } = 100;
    }
}