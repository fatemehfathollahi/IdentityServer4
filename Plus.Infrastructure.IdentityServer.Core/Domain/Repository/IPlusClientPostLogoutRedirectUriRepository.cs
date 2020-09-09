using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusClientPostLogoutRedirectUriRepository
    {
        Task Insert(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri);

        Task Update(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri);

        Task DeleteAll(int clientId);

        Task Delete(int clientPostLogoutRedirectUriId);

        Task<ClientPostLogoutRedirectUri> GetById(int clientPostLogoutRedirectUriId);

        Task<IEnumerable<ClientPostLogoutRedirectUri>> GetAll();

        Task<IEnumerable<ClientPostLogoutRedirectUri>> GetPostLogoutRedirectUrisByClientId(int clientId);
    }
}
