using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusApiResourcePropertyService : IPlusApiResourcePropertyService
    {
        private readonly IPlusApiResourcePropertyRepository _apiResourePropertyRepository;

        public PlusApiResourcePropertyService(IPlusApiResourcePropertyRepository apiPropertyRepository)
        {
            _apiResourePropertyRepository = apiPropertyRepository;
        }

        public ApiResourceProperty GetById(int propertyId)
        {
            return _apiResourePropertyRepository.GetById(propertyId);
        }

        public IEnumerable<ApiResourceProperty> GetPropertiesByResourceId(int resourceId)
        {
            return _apiResourePropertyRepository.GetPropertiesByResourceId(resourceId);
        }

        public void Insert(ApiResourceProperty apiProperty)
        {
            _apiResourePropertyRepository.Insert(apiProperty);
        }

        public void Update(ApiResourceProperty apiProperty)
        {
            _apiResourePropertyRepository.Update(apiProperty);
        }

        public void Delete(int propertyId)
        {
            _apiResourePropertyRepository.Delete(propertyId);
        }

        public void DeleteAll(int resourceId)
        {
            _apiResourePropertyRepository.DeleteAll(resourceId);
        }

        public IEnumerable<ApiResourceProperty> GetAll()
        {
           return  _apiResourePropertyRepository.GetAll();
        }
    }
}
