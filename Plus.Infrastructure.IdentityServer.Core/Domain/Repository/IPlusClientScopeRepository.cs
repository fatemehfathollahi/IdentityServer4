using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public  interface IPlusClientScopeRepository
    {
        Task Insert(ClientScope clientScope);

        Task Update(ClientScope clientScope);

        Task DeleteAll(int clientId);

        Task Delete(int scopeId);

        Task<ClientScope> GetById(int scopeId);

        Task<IEnumerable<ClientScope>> GetAll();

        Task<IEnumerable<ClientScope>> GetScopesByClientId(int clientId);
    }
}
