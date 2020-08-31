using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Models
{
    public class ApiScopeProperty:Property
    {
        public int ScopeId { get; set; }
        public ApiScope Scope { get; set; }
    }
}
