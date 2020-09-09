using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientClaimRepository
    {
        Task Insert(ClientClaim clientClaim);

        Task Update(ClientClaim clientClaim);

        Task DeleteAll(int clientId);

        Task Delete(int claimId);

        Task<ClientClaim> GetById(int claimId);

        Task<IEnumerable<ClientClaim>> GetAll();

        Task<IEnumerable<ClientClaim>> GetClaimsByClientId(int clientId);
    }
}
