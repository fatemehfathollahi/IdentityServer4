using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models
{
    public class AddEditIdentityResourceViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; } = false;
        public bool Required { get; set; } = false;
        public bool Emphasize { get; set; } = false;
        public bool ShowInDiscoveryDocument { get; set; } = false;
        [Required]
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool NonEditable { get; set; } = false;
    }
}
