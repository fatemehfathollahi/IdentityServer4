using Microsoft.AspNetCore.Mvc;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface  IPlusIdentityResourceService
    {
        Task Insert(IdentityResource identityResource);
        Task Update(IdentityResource identityResource);
        Task Delete(int id);
        Task<IdentityResource> GetById(int id);
        Task<IEnumerable<IdentityResource>> GetAll();
    }
}
