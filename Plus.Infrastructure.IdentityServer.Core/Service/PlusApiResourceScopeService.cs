using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusApiResourceScopeService : IPlusApiResourceScopeService
    {
        private readonly IPlusApiResourceScopeRepository _apiResoureScopeRepository;

        public PlusApiResourceScopeService(IPlusApiResourceScopeRepository apiScopeRepository)
        {
            _apiResoureScopeRepository = apiScopeRepository;
        }

        public ApiResourceScope GetById(int resourceId, int scopId)
        {
            return _apiResoureScopeRepository.GetById(resourceId,scopId);
        }
       
        public void Insert(int resourceId, ApiResourceScope apiScope)
        {
            _apiResoureScopeRepository.Insert(resourceId,apiScope);
        }

        public void Update(int resourceId, ApiResourceScope apiScope)
        {
            _apiResoureScopeRepository.Update(resourceId,apiScope);
        }

        public void Delete(int resourceId, int scopId)
        {
            _apiResoureScopeRepository.Delete(resourceId, scopId);
        }

        public IEnumerable<ApiResourceScope> GetScopesByResourceId(int resourceId)
        {
            return _apiResoureScopeRepository.GetScopesByResourceId(resourceId);
        }
    }
}
