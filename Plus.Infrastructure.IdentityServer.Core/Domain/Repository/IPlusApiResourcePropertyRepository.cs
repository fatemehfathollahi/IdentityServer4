using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourcePropertyRepository
    {
        Task Insert(ApiResourceProperty apiProperty);

        Task Update(ApiResourceProperty apiProperty);

        Task Delete(int propertyId);

        Task DeleteAll(int resourceId);

        Task<ApiResourceProperty> GetById(int propertyId);

        Task<IEnumerable<ApiResourceProperty>> GetAll();

        Task<IEnumerable<ApiResourceProperty>> GetPropertiesByResourceId(int resourceId);
    }
}
