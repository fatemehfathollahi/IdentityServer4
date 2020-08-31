using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models.ApiResource
{
    public class AddEditApiResourceViewModel
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public bool NonEditable { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }

        public IEnumerable<ApiResourceScopeViewModel> Scopes { get; set; }
        public IEnumerable<ApiResourceSecretViewModel> Secrets { get; set; }
        public IEnumerable<ApiResourceClaimViewModel> UserClaims { get; set; }
        public IEnumerable<ApiResourcePropertyViewModel> Properties { get; set; }

    }
}
