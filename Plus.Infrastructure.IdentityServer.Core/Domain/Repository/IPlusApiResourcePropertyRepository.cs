using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourcePropertyRepository: IDisposable
    {
        void Insert(int resourceId, ApiResourceProperty apiProperty);

        void Update(int resourceId, ApiResourceProperty apiProperty);

        void Delete(int resourceId, int propertyId);

        ApiResourceProperty GetById(int resourceId, int propertyId);

        // IEnumerable<ApiResourceSecret> GetAll();

        IEnumerable<ApiResourceProperty> GetPropertiesByResourceId(int resourceId);
    }
}
