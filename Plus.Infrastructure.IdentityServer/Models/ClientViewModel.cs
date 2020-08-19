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

        public List<ClientSecret> ClientSecrets { get; set; }

        public List<ClientScope> AllowedScopes { get; set; }

        public List<ClientGrantType> AllowedGrantTypes { get; set; }
    }
}
