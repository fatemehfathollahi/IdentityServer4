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

        public ApiResourceScope GetById(int scopId)
        {
            return _apiResoureScopeRepository.GetById(scopId);
        }
       
        public void Insert(ApiResourceScope apiScope)
        {
            _apiResoureScopeRepository.Insert(apiScope);
        }

        public void Update(ApiResourceScope apiScope)
        {
            _apiResoureScopeRepository.Update(apiScope);
        }

        public void Delete(int scopId)
        {
            _apiResoureScopeRepository.Delete(scopId);
        }

        public IEnumerable<ApiResourceScope> GetScopesByResourceId(int resourceId)
        {
            return _apiResoureScopeRepository.GetScopesByResourceId(resourceId);
        }

        public void DeleteAll(int resourceId)
        {
           _apiResoureScopeRepository.DeleteAll(resourceId);
        }

        public IEnumerable<ApiResourceScope> GetAll()
        {
            return _apiResoureScopeRepository.GetAll();
        }
    }
}
