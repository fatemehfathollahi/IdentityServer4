
using System;
using Microsoft.EntityFrameworkCore;

namespace Plus.Infrastructure.IdentityServer.Core.Options
{
   
    public class OperationalStoreOptions
    {
      
        public Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }

        public Action<IServiceProvider, DbContextOptionsBuilder> ResolveDbContextOptions { get; set; }

        public string DefaultSchema { get; set; } = null;

        public TableConfiguration PlusApiPersistedGrants { get; set; } = new TableConfiguration("PlusApiPersistedGrants");
   
        public TableConfiguration PlusDeviceFlowCodes { get; set; } = new TableConfiguration("PlusDeviceFlowCodes");
       
        public bool EnableTokenCleanup { get; set; } = false;

        public int TokenCleanupInterval { get; set; } = 3600;

        public int TokenCleanupBatchSize { get; set; } = 100;
    }
}