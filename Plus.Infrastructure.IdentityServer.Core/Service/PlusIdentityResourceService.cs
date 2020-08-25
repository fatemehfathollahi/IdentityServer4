using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusIdentityResourceService : IPlusIdentityResourceService,IDisposable
    {
        private readonly IPlusIdentityResourceRepository identityResourceRepository;

        public PlusIdentityResourceService(IPlusIdentityResourceRepository identityResourceRepository)
        {
            this.identityResourceRepository = identityResourceRepository;
        }

        public void Dispose()
        {

        }

        public IEnumerable<IdentityResource> GetAll()
        {
           return identityResourceRepository.GetAll();
        }

        public IdentityResource GetById(int id)
        {
           return identityResourceRepository.GetById(id);
        }

        public void Insert(IdentityResource identityResource)
        {
            identityResourceRepository.Insert(identityResource);
        }

        public void Update(IdentityResource identityResource)
        {
            identityResourceRepository.Update(identityResource);
        }
    }
}
