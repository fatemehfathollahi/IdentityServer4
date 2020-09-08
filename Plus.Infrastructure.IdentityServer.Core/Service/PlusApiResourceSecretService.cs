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

        public ApiResourceSecret GetById(int secretId)
        {
            return _apiResoureSecretRepository.GetById(secretId);
        }

        public IEnumerable<ApiResourceSecret> GetSecretsByResourceId(int resourceId)
        {
            return _apiResoureSecretRepository.GetSecretsByResourceId(resourceId);
        }

        public void Insert(ApiResourceSecret apiSecret)
        {
            _apiResoureSecretRepository.Insert(apiSecret);
        }

        public void Update(ApiResourceSecret apiSecret)
        {
            _apiResoureSecretRepository.Update(apiSecret);
        }

        public void Delete(int secretId)
        {
            _apiResoureSecretRepository.Delete(secretId);
        }

        public void DeleteAll(int resourceId)
        {
            _apiResoureSecretRepository.DeleteAll(resourceId);
        }

        public IEnumerable<ApiResourceSecret> GetAll()
        {
            return _apiResoureSecretRepository.GetAll();
        }
    }
}
