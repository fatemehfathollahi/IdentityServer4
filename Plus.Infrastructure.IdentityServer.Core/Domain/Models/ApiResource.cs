using System;
using System.Collections.Generic;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ApiResource
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } 
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string AllowedAccessTokenSigningAlgorithms { get; set; }
        public List<ApiResourceSecret> Secrets { get; set; } = new List<ApiResourceSecret>();
        public List<ApiResourceScope> Scopes { get; set; } = new List<ApiResourceScope>();
        public List<ApiResourceClaim> UserClaims { get; set; } = new List<ApiResourceClaim>();
        public List<ApiResourceProperty> Properties { get; set; } = new List<ApiResourceProperty>();
        public DateTime Created { get; set; } 
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool NonEditable { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
    }
}
