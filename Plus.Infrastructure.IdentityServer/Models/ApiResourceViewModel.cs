using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models
{
    public class ApiResourceViewModel
    {
        public bool Enabled { get; set; } 
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? LastAccessed { get; set; }
        public DateTime Created { get; set; }
        public bool NonEditable { get; set; }
       
        public IEnumerable<ScopeViewModel> Scopes { get; set; }
      
    }
}
