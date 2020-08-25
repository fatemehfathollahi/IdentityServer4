using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusIdentityResourceRepository
    {
        void Insert(IdentityResource identityResource);

        void Update(IdentityResource identityResource);

        IdentityResource GetById(int id);

        IEnumerable<IdentityResource> GetAll();
    }
}
