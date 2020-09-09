using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public  interface IPlusClientIdPRestrictionRepository
    {
        Task Insert(ClientIdPRestriction clientIdPRestriction);

        Task Update(ClientIdPRestriction clientIdPRestriction);

        Task DeleteAll(int clientId);

        Task Delete(int clientIdPRestrictionId);

        Task<ClientIdPRestriction> GetById(int clientIdPRestrictionId);

        Task<IEnumerable<ClientIdPRestriction>> GetAll();

        Task<IEnumerable<ClientIdPRestriction>> GetClientIdPRestrictionsByClientId(int clientId);
    }
}
