﻿using IdentityServer4.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
  
    public interface IPlusApiResourceService
    {
        Task<IdentityServer4.Models.ApiResource> CreateAsync(Models.ApiResource apiResource);
    }
}