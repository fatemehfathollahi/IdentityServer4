using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Plus.Infrastructure.IdentityServer.Models.Client
{
    public class AddEditClientViewModel
    {
        public int Id { get; set; }
        [Required]
        public int AccessTokenLifetime { get; set; }
        [Required]
        public int AuthorizationCodeLifetime { get; set; }
        public int? ConsentLifetime { get; set; }
        [Required]
        public int AbsoluteRefreshTokenLifetime { get; set; } 
        [Required]
        public int SlidingRefreshTokenLifetime { get; set; }
        [Required]
        public int RefreshTokenUsage { get; set; }
        [Required]
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        [Required]
        public int RefreshTokenExpiration { get; set; }
        [Required]
        public int AccessTokenType { get; set; }
        [Required]
        public bool EnableLocalLogin { get; set; }
        [Required]
        public bool IncludeJwtId { get; set; }
        [Required]
        public bool AlwaysSendClientClaims { get; set; }
        public string ClientClaimsPrefix { get; set; }
        public string PairWiseSubjectSalt { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public int? UserSsoLifetime { get; set; } 
        public string UserCodeType { get; set; }
        public string AllowedIdentityTokenSigningAlgorithms { get; set; }
        [Required]
        public int IdentityTokenLifetime { get; set; } 
        [Required]
        public bool AllowOfflineAccess { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ProtocolType { get; set; }
        [Required]
        public bool RequireClientSecret { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string ClientUri { get; set; }
        public string LogoUri { get; set; }
        [Required]
        public bool RequireConsent { get; set; }
        [Required]
        public int DeviceCodeLifetime { get; set; } 
        [Required]
        public bool AllowRememberConsent { get; set; }
        [Required]
        public bool RequirePkce { get; set; }
        [Required]
        public bool AllowPlainTextPkce { get; set; }
        [Required]
        public bool RequireRequestObject { get; set; }
        [Required]
        public bool AllowAccessTokensViaBrowser { get; set; }
        public string FrontChannelLogoutUri { get; set; }
        [Required]
        public bool FrontChannelLogoutSessionRequired { get; set; }
        public string BackChannelLogoutUri { get; set; }
        [Required]
        public bool BackChannelLogoutSessionRequired { get; set; }
        [Required]
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        [Required]
        public bool NonEditable { get; set; }


        public List<RedirectUriItem> RedirectUris { get; set; }
        public List<PostLogoutRedirectUriItem> PostLogoutRedirectUris { get; set; }
        public List<CorsOriginItem> CorsOrigins { get; set; }
        public List<IdPRestrictionItem> Restrictions { get; set; }
        public List<GrantTypeItem> GrantTypes { get; set; }
        public List<SecretItem> Secrets { get; set; }
        public List<ScopeItem> Scopes { get; set; }
        public List<ClientClaimItem> Claims { get; set; }
        public List<PropertyItem> Properties { get; set; }

        public AddEditClientViewModel()
        {
            RedirectUris = new List<RedirectUriItem>();
            PostLogoutRedirectUris = new List<PostLogoutRedirectUriItem>();
            CorsOrigins = new List<CorsOriginItem>();
            Restrictions = new List<IdPRestrictionItem>();
            GrantTypes = new List<GrantTypeItem>();
            Secrets = new List<SecretItem>();
            Scopes = new List<ScopeItem>();
            Claims = new List<ClientClaimItem>();
            Properties = new List<PropertyItem>();
        }
    }
}
