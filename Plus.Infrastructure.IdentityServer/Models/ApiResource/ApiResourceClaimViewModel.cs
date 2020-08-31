using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models.ApiResource
{
    public class ApiResourceClaimViewModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int ApiResourceId { get; set; }
    }
}
