﻿

using IdentityServer4.Models;
using System;
using System.Collections.Generic;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusClient
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public string ClientId { get; set; }
        public string ProtocolType { get; set; } = "oidc";
        public List<PlusClientSecret> ClientSecrets { get; set; }
        public bool RequireClientSecret { get; set; } = true;
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string ClientUri { get; set; }
        public string LogoUri { get; set; }
        public bool RequireConsent { get; set; } = true;
        public bool AllowRememberConsent { get; set; } = true;
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public List<PlusClientGrantType> AllowedGrantTypes { get; set; }
        public bool RequirePkce { get; set; }
        public bool AllowPlainTextPkce { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public List<PlusClientRedirectUri> RedirectUris { get; set; }
        public List<PlusClientPostLogoutRedirectUri> PostLogoutRedirectUris { get; set; }
        public string FrontChannelLogoutUri { get; set; }
        public bool FrontChannelLogoutSessionRequired { get; set; } = true;
        public string BackChannelLogoutUri { get; set; }
        public bool BackChannelLogoutSessionRequired { get; set; } = true;
        public bool AllowOfflineAccess { get; set; }
        public List<PlusClientScope> AllowedScopes { get; set; }
        public int IdentityTokenLifetime { get; set; } = 300;
        public int AccessTokenLifetime { get; set; } = 3600;
        public int AuthorizationCodeLifetime { get; set; } = 300;
        public int? ConsentLifetime { get; set; } = null;
        public int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;
        public int SlidingRefreshTokenLifetime { get; set; } = 1296000;
        public int RefreshTokenUsage { get; set; } = (int)TokenUsage.OneTimeOnly;
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        public int RefreshTokenExpiration { get; set; } = (int)TokenExpiration.Absolute;
        public int AccessTokenType { get; set; } = (int)0; // AccessTokenType.Jwt;
        public bool EnableLocalLogin { get; set; } = true;
        public List<PlusClientIdPRestriction> IdentityProviderRestrictions { get; set; }
        public bool IncludeJwtId { get; set; }
        public List<PlusClientClaim> Claims { get; set; }
        public bool AlwaysSendClientClaims { get; set; }
        public string ClientClaimsPrefix { get; set; } = "client_";
        public string PairWiseSubjectSalt { get; set; }
        public List<PlusClientCorsOrigin> AllowedCorsOrigins { get; set; }
        public List<PlusClientProperty> Properties { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public int? UserSsoLifetime { get; set; }
        public string UserCodeType { get; set; }
        public int DeviceCodeLifetime { get; set; } = 300;
        public bool NonEditable { get; set; }
    }
}