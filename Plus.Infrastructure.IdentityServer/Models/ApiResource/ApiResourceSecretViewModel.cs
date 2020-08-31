using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models.ApiResource
{
    public class ApiResourceSecretViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; } 
        public DateTime Created { get; set; }

        public int ApiResourceId { get; set; }
    }
}
