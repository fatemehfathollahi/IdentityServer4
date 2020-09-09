using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models
{
    public class SecretItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [Required]
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
