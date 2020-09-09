using System.Collections.Generic;
using System.Threading.Tasks;
using  Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusClientService
    {
        Task<int> Insert(Client client);
        Task<int> Update(Client client);
        Task Delete(int id);
        Task<Client> GetById(int id);
        Task<IEnumerable<Client>> GetAll();

        Task<IEnumerable<ClientScope>> GetScopesByClientId(int clientId);
        Task AddScope(ClientScope clientScope);
        Task UpdateScope(ClientScope clientScope);

        Task<IEnumerable<ClientSecret>> GetSecretsByClientId(int clientId);
        Task AddSecret(ClientSecret clientSecret);
        Task UpdateSecret(ClientSecret clientSecret);

        Task<IEnumerable<ClientRedirectUri>> GetRedirectUriByClientId(int clientId);
        Task AddRedirectUri(ClientRedirectUri clientRedirectUri);
        Task UpdateRedirectUri(ClientRedirectUri clientRedirectUri);

        Task<IEnumerable<ClientProperty>> GetPropertiesByClientId(int clientId);
        Task AddProperty(ClientProperty clientProperty);
        Task UpdateProperty(ClientProperty clientProperty);

        Task<IEnumerable<ClientPostLogoutRedirectUri>> GetPostLogoutRedirectUrisByClientId(int clientId);
        Task AddPostLogoutRedirectUri(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri);
        Task UpdatePostLogoutRedirectUri(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri);

        Task<IEnumerable<ClientIdPRestriction>> GetClientIdPRestrictionsByClientId(int clientId);
        Task AddRestriction(ClientIdPRestriction clientIdPRestriction);
        Task UpdateRestriction(ClientIdPRestriction clientIdPRestriction);

        Task<IEnumerable<ClientGrantType>> GetGrantTypesByClientId(int clientId);
        Task AddGrantType(ClientGrantType clientGrantType);
        Task UpdateGrantType(ClientGrantType clientGrantType);

        Task<IEnumerable<ClientClaim>> GetClaimsByClientId(int clientId);
        Task AddClaim(ClientClaim clientClaim);
        Task UpdateClaim(ClientClaim clientClaim);

        Task<IEnumerable<ClientCorsOrigin>> GetCorsOriginsByClientId(int clientId);
        Task AddCorsOrigin(ClientCorsOrigin clientCorsOrigin);
        Task UpdateCorsOrigin(ClientCorsOrigin clientCorsOrigin);
    }
}
