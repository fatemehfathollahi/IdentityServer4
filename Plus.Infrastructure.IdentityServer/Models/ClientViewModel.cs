using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models
{
    public class ClientViewModel
    {
        public string ClientId { get; set; }

        public List<PlusClientSecret> ClientSecrets { get; set; }

        public List<PlusClientScope> AllowedScopes { get; set; }

        public List<PlusClientGrantType> AllowedGrantTypes { get; set; }
    }
}
