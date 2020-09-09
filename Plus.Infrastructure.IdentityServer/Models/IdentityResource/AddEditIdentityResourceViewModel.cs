using System;
using System.ComponentModel.DataAnnotations;

namespace Plus.Infrastructure.IdentityServer.Models
{
    public class AddEditIdentityResourceViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; } 
        public bool Required { get; set; } 
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; } 
        [Required]
        public DateTime Created { get; set; } 
        public DateTime? Updated { get; set; }
        public bool NonEditable { get; set; } 
    }
}
