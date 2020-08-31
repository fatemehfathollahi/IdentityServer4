using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusApiResourceSecretService : IPlusApiResourceSecretService
    {
        private readonly IPlusApiResourceSecretRepository _apiResoureSecretRepository;

        public PlusApiResourceSecretService(IPlusApiResourceSecretRepository apiSecretRepository)
        {
            _apiResoureSecretRepository = apiSecretRepository;
        }

        public ApiResourceSecret GetById(int resourceId, int secretId)
        {
            return _apiResoureSecretRepository.GetById(resourceId, secretId);
        }

        public IEnumerable<ApiResourceSecret> GetSecretsByResourceId(int resourceId)
        {
            return _apiResoureSecretRepository.GetSecretsByResourceId(resourceId);
        }

        public void Insert(int resourceId, ApiResourceSecret apiSecret)
        {
            _apiResoureSecretRepository.Insert(resourceId, apiSecret);
        }

        public void Update(int resourceId, ApiResourceSecret apiSecret)
        {
            _apiResoureSecretRepository.Update(resourceId, apiSecret);
        }

        public void Delete(int resourceId, int secretId)
        {
            _apiResoureSecretRepository.Delete(resourceId, secretId);
        }
    }
}
