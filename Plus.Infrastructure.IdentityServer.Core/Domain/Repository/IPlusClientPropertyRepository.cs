using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientPropertyRepository
    {
        Task Insert(ClientProperty clientProperty);

        Task Update(ClientProperty clientProperty);

        Task Delete(int propertyId);

        Task DeleteAll(int clientId);

        Task<ClientProperty> GetById(int propertyId);

        Task<IEnumerable<ClientProperty>> GetAll();

        Task<IEnumerable<ClientProperty>> GetPropertiesByClientId(int clientId);
    }
}
