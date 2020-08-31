using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface  IPlusIdentityResourceService
    {
        void Insert(IdentityResource identityResource);
        void Update(IdentityResource identityResource);
        void Delete(int id);
        IdentityResource GetById(int id);
        IEnumerable<IdentityResource> GetAll();
    }
}
