using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Models
{
    public class PostLogoutRedirectUriItem
    {
        public int Id { get; set; }
        public string PostLogoutRedirectUri { get; set; }
    }
}
