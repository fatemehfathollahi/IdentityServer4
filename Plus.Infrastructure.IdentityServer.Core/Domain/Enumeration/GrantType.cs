using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Enumeration
{
    public enum GrantType
    {
        Implicit = 1,
        ImplicitAndClientCredentials = 3,
        Code = 4,
        CodeAndClientCredentials=5,
        Hybrid=6,
        HybridAndClientCredentials = 7,
        ClientCredentials = 8,
        ResourceOwnerPassword = 9,
        ResourceOwnerPasswordAndClientCredentials = 10,
        DeviceFlow = 11
    }
}
