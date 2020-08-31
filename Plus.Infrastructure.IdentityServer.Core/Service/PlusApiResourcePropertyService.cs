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

        public ApiResourceProperty GetById(int resourceId, int propertyId)
        {
            return _apiResourePropertyRepository.GetById(resourceId, propertyId);
        }

        public IEnumerable<ApiResourceProperty> GetPropertiesByResourceId(int resourceId)
        {
            return _apiResourePropertyRepository.GetPropertiesByResourceId(resourceId);
        }

        public void Insert(int resourceId, ApiResourceProperty apiProperty)
        {
            _apiResourePropertyRepository.Insert(resourceId, apiProperty);
        }

        public void Update(int resourceId, ApiResourceProperty apiProperty)
        {
            _apiResourePropertyRepository.Update(resourceId, apiProperty);
        }

        public void Delete(int resourceId, int propertyId)
        {
            _apiResourePropertyRepository.Delete(resourceId, propertyId);
        }
    }
}
