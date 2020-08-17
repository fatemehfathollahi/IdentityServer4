using System;
using System.Collections.Generic;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class PlusApiResource
    {
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<PlusApiSecret> Secrets { get; set; }
        public List<PlusApiScope> Scopes { get; set; }
        public List<PlusApiResourceClaim> UserClaims { get; set; }
        public List<PlusApiResourceProperty> Properties { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool NonEditable { get; set; }
    }
}
