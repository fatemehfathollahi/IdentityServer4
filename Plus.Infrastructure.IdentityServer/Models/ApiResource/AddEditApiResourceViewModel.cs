using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models.ApiResource
{
    public class AddEditApiResourceViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string AllowedAccessTokenSigningAlgorithms { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public bool Enabled { get; set; } = false;
        public bool NonEditable { get; set; } = false;
        public bool ShowInDiscoveryDocument { get; set; } = false;
       
        public List<ScopeItem> Scopes { get; set; }
        public List<SecretItem> Secrets { get; set; } 
        public List<ClaimItem> Claims { get; set; }
        public List<PropertyItem> Properties { get; set; }

       // public bool IsEdit { get; set; }

        public AddEditApiResourceViewModel()
        {
          
            Scopes = new List<ScopeItem>();
            Claims = new List<ClaimItem>();
            Secrets = new List<SecretItem>();
            Properties = new List<PropertyItem>();
           
        }

    }
}
