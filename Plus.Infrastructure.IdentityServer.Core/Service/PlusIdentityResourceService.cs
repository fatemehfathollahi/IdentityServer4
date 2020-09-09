using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusIdentityResourceService : IPlusIdentityResourceService
    {
        private readonly IPlusIdentityResourceRepository _identityResourceRepository;

        public PlusIdentityResourceService(IPlusIdentityResourceRepository identityResourceRepository)
        {
            _identityResourceRepository = identityResourceRepository;
        }


        public async Task<IEnumerable<IdentityResource>> GetAll()
        {
           return await _identityResourceRepository.GetAll();
        }

        public async Task<IdentityResource> GetById(int id)
        {
           return await _identityResourceRepository.GetById(id);
        }

        public async Task Insert(IdentityResource identityResource)
        {
           await _identityResourceRepository.Insert(identityResource);
        }

        public async Task Update(IdentityResource identityResource)
        {
           await  _identityResourceRepository.Update(identityResource);
        }
        public async Task Delete(int id)
        {
           await  _identityResourceRepository.Delete(id);
        }
    }
}
