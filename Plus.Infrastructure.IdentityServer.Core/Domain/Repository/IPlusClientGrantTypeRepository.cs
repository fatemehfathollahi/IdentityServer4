using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientGrantTypeRepository
    {
        Task Insert(ClientGrantType clientGrantType);

        Task Update(ClientGrantType clientGrantType);

        Task DeleteAll(int clientId);

        Task Delete(int grantTypeId);

        Task<ClientGrantType> GetById(int grantTypeId);

        Task<IEnumerable<ClientGrantType>> GetAll();

        Task<IEnumerable<ClientGrantType>> GetGrantTypesByClientId(int clientId);
    }
}
