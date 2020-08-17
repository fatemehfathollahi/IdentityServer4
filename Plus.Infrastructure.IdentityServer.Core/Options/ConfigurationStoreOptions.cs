

using System;
using Microsoft.EntityFrameworkCore;

namespace Plus.Infrastructure.IdentityServer.Core.Options
{
    public class ConfigurationStoreOptions
    {
       
        public Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }
        
        public Action<IServiceProvider, DbContextOptionsBuilder> ResolveDbContextOptions { get; set; }

       
        public string DefaultSchema { get; set; } = null;

      
        public TableConfiguration PlusIdentityResource { get; set; } = new TableConfiguration("PlusIdentityResources");
        
        public TableConfiguration PlusIdentityClaim { get; set; } = new TableConfiguration("PlusIdentityClaims");

        
        public TableConfiguration PlusApiResource { get; set; } = new TableConfiguration("PlusApiResources");
       
        public TableConfiguration PlusApiSecret { get; set; } = new TableConfiguration("PlusApiSecrets");
       
        public TableConfiguration PlusApiScope { get; set; } = new TableConfiguration("PlusApiScopes");
      
        public TableConfiguration PlusApiClaim { get; set; } = new TableConfiguration("PlusApiClaims");
       
        public TableConfiguration PlusApiScopeClaim { get; set; } = new TableConfiguration("PlusApiScopeClaims");

       
        public TableConfiguration PlusClient { get; set; } = new TableConfiguration("PlusClients");
        
        public TableConfiguration PlusClientGrantType { get; set; } = new TableConfiguration("PlusClientGrantTypes");
       
        public TableConfiguration PlusClientRedirectUri { get; set; } = new TableConfiguration("PlusClientRedirectUris");
       
        public TableConfiguration PlusClientPostLogoutRedirectUri { get; set; } = new TableConfiguration("PlusClientPostLogoutRedirectUris");
       
        public TableConfiguration PlusClientScopes { get; set; } = new TableConfiguration("PlusClientScopes");
       
        public TableConfiguration PlusClientSecret { get; set; } = new TableConfiguration("PlusClientSecrets");
      
        public TableConfiguration PlusClientClaim { get; set; } = new TableConfiguration("PlusClientClaims");
       
        public TableConfiguration PlusClientIdPRestriction { get; set; } = new TableConfiguration("PlusClientIdPRestrictions");
       
        public TableConfiguration PlusClientCorsOrigin { get; set; } = new TableConfiguration("PlusClientCorsOrigins");
       
        public TableConfiguration PlusClientProperty { get; set; } = new TableConfiguration("PlusClientProperties");
        
        public TableConfiguration PlusApiResourceProperty { get; set; } = new TableConfiguration("PlusApiProperties");
       
        public TableConfiguration PlusIdentityResourceProperty { get; set; } = new TableConfiguration("PlusIdentityResourdeProperties");
    }
}