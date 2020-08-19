

using System;
using Microsoft.EntityFrameworkCore;

namespace Plus.Infrastructure.IdentityServer.Core.Options
{
    public class IdentityConfigurationStoreOptions
    {
       
        public Action<DbContextOptionsBuilder> ConfigureDbContext { get; set; }
        
        public Action<IServiceProvider, DbContextOptionsBuilder> ResolveDbContextOptions { get; set; }

       
        public string DefaultSchema { get; set; } = null;

      
        public IdentityTableConfiguration IdentityResource { get; set; } = new IdentityTableConfiguration("IdentityResources");
        
        public IdentityTableConfiguration IdentityClaim { get; set; } = new IdentityTableConfiguration("IdentityClaims");

        
        public IdentityTableConfiguration ApiResource { get; set; } = new IdentityTableConfiguration("ApiResources");
       
        public IdentityTableConfiguration ApiSecret { get; set; } = new IdentityTableConfiguration("ApiSecrets");
       
        public IdentityTableConfiguration ApiScope { get; set; } = new IdentityTableConfiguration("ApiScopes");
      
        public IdentityTableConfiguration ApiClaim { get; set; } = new IdentityTableConfiguration("ApiClaims");
       
        public IdentityTableConfiguration ApiScopeClaim { get; set; } = new IdentityTableConfiguration("ApiScopeClaims");

       
        public IdentityTableConfiguration Client { get; set; } = new IdentityTableConfiguration("Clients");
        
        public IdentityTableConfiguration ClientGrantType { get; set; } = new IdentityTableConfiguration("ClientGrantTypes");
       
        public IdentityTableConfiguration ClientRedirectUri { get; set; } = new IdentityTableConfiguration("ClientRedirectUris");
       
        public IdentityTableConfiguration ClientPostLogoutRedirectUri { get; set; } = new IdentityTableConfiguration("ClientPostLogoutRedirectUris");
       
        public IdentityTableConfiguration ClientScopes { get; set; } = new IdentityTableConfiguration("ClientScopes");
       
        public IdentityTableConfiguration ClientSecret { get; set; } = new IdentityTableConfiguration("ClientSecrets");
      
        public IdentityTableConfiguration ClientClaim { get; set; } = new IdentityTableConfiguration("ClientClaims");
       
        public IdentityTableConfiguration ClientIdPRestriction { get; set; } = new IdentityTableConfiguration("ClientIdPRestrictions");
       
        public IdentityTableConfiguration ClientCorsOrigin { get; set; } = new IdentityTableConfiguration("ClientCorsOrigins");
       
        public IdentityTableConfiguration ClientProperty { get; set; } = new IdentityTableConfiguration("ClientProperties");
        
        public IdentityTableConfiguration ApiResourceProperty { get; set; } = new IdentityTableConfiguration("ApiProperties");
       
        public IdentityTableConfiguration IdentityResourceProperty { get; set; } = new IdentityTableConfiguration("IdentityResourdeProperties");
    }
}