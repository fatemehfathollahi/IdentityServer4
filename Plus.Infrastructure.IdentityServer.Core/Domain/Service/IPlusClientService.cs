using System.Collections.Generic;
using  Plus.Infrastructure.IdentityServer.Core.Domain.Models;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusClientService
    {
        int Insert(Client client);
        int Update(Client client);
        int Delete(int id);
        Client GetById(int id);
        IEnumerable<Client> GetAll();

        IEnumerable<ClientScope> GetScopesByClientId(int clientId);
        void AddScope(ClientScope clientScope);
        void UpdateScope(ClientScope clientScope);

        IEnumerable<ClientSecret> GetSecretsByClientId(int clientId);
        void AddSecret(ClientSecret clientSecret);
        void UpdateSecret(ClientSecret clientSecret);

        IEnumerable<ClientRedirectUri> GetRedirectUriByClientId(int clientId);
        void AddRedirectUri(ClientRedirectUri clientRedirectUri);
        void UpdateRedirectUri(ClientRedirectUri clientRedirectUri);

        IEnumerable<ClientProperty> GetPropertiesByClientId(int clientId);
        void AddProperty(ClientProperty clientProperty);
        void UpdateProperty(ClientProperty clientProperty);

        IEnumerable<ClientPostLogoutRedirectUri> GetPostLogoutRedirectUrisByClientId(int clientId);
        void AddPostLogoutRedirectUri(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri);
        void UpdatePostLogoutRedirectUri(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri);

        IEnumerable<ClientIdPRestriction> GetClientIdPRestrictionsByClientId(int clientId);
        void AddRestriction(ClientIdPRestriction clientIdPRestriction);
        void UpdateRestriction(ClientIdPRestriction clientIdPRestriction);

        IEnumerable<ClientGrantType> GetGrantTypesByClientId(int clientId);
        void AddGrantType(ClientGrantType clientGrantType);
        void UpdateGrantType(ClientGrantType clientGrantType);

        IEnumerable<ClientClaim> GetClaimsByClientId(int clientId);
        void AddClaim(ClientClaim clientClaim);
        void UpdateClaim(ClientClaim clientClaim);

        IEnumerable<ClientCorsOrigin> GetCorsOriginsByClientId(int clientId);
        void AddCorsOrigin(ClientCorsOrigin clientCorsOrigin);
        void UpdateCorsOrigin(ClientCorsOrigin clientCorsOrigin);
    }
}
