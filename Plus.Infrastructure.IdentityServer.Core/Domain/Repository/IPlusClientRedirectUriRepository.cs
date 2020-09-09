using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientRedirectUriRepository 
    {
        Task Insert(ClientRedirectUri clientRedirectUri);

        Task Update(ClientRedirectUri clientRedirectUri);

        Task DeleteAll(int clientId);

        Task Delete(int clientRedirectUriId);

        Task<ClientRedirectUri> GetById(int clientRedirectUriId);

        Task<IEnumerable<ClientRedirectUri>> GetAll();

        Task<IEnumerable<ClientRedirectUri>> GetRedirectUriByClientId(int clientId);
    }
}
