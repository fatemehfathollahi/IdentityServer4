using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusApiResourceService : IPlusApiResourceService
    {
        private readonly IPlusApiResourceRepository _apiResourceRepository;

        public PlusApiResourceService(IPlusApiResourceRepository apiResourceRepository)
        {
            _apiResourceRepository = apiResourceRepository;
        }

        public IEnumerable<ApiResource> GetAll()
        {
            return _apiResourceRepository.GetAll();
        }

        public ApiResource GetById(int id)
        {
            return _apiResourceRepository.GetById(id);
        }

        public void Insert(ApiResource apiResource)
        {
            _apiResourceRepository.Insert(apiResource);
        }

        public void Update(ApiResource apiResource)
        {
            _apiResourceRepository.Update(apiResource);
        }

        public void Delete(int id)
        {
            _apiResourceRepository.Delete(id);
        }

        
    }
}
