using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusIdentityResourceService : IPlusIdentityResourceService
    {
        private readonly IPlusIdentityResourceRepository _identityResourceRepository;

        public PlusIdentityResourceService(IPlusIdentityResourceRepository identityResourceRepository)
        {
            _identityResourceRepository = identityResourceRepository;
        }


        public IEnumerable<IdentityResource> GetAll()
        {
           return _identityResourceRepository.GetAll();
        }

        public IdentityResource GetById(int id)
        {
           return _identityResourceRepository.GetById(id);
        }

        public void Insert(IdentityResource identityResource)
        {
            _identityResourceRepository.Insert(identityResource);
        }

        public void Update(IdentityResource identityResource)
        {
            _identityResourceRepository.Update(identityResource);
        }
        public void Delete(int id)
        {
            _identityResourceRepository.Delete(id);
        }

    }
}
