using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusApiResourcePropertyService
    {
        void Insert(int resourceId, ApiResourceProperty apiProperty);

        void Update(int resourceId, ApiResourceProperty apiProperty);

        void Delete(int resourceId, int propertyId);

        ApiResourceProperty GetById(int resourceId, int propertyId);

        IEnumerable<ApiResourceProperty> GetPropertiesByResourceId(int resourceId);
    }
}
