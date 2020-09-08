using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusApiResourcePropertyService
    {
        void Insert(ApiResourceProperty apiProperty);

        void Update(ApiResourceProperty apiProperty);

        void Delete(int propertyId);

        void DeleteAll(int resourceId);

        ApiResourceProperty GetById(int propertyId);

        IEnumerable<ApiResourceProperty> GetAll();

        IEnumerable<ApiResourceProperty> GetPropertiesByResourceId(int resourceId);
    }
}
