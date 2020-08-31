﻿using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
  
    public interface IPlusApiResourceService
    {
        void Insert(ApiResource apiResource);
        void Update(ApiResource apiResource);
        void Delete(int id);
        ApiResource GetById(int id);
        IEnumerable<ApiResource> GetAll();
    }
}