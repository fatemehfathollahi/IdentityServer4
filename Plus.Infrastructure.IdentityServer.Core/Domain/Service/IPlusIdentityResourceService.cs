﻿using IdentityServer4.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface  IPlusIdentityResourceService
    {
        Task<IdentityResource> CreateAsync(PlusIdentityResource identityResource);
    }
}