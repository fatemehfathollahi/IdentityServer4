using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusClientService : IPlusClientService
    {
        private readonly IIdentityUnitOfWork _identityUnitOfWork;
        public PlusClientService(IIdentityUnitOfWork identityUnitOfWork)
        {
            _identityUnitOfWork = identityUnitOfWork;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
           return await _identityUnitOfWork.PlusClientRepository.GetAll();
        }
        public async Task<Client> GetById(int id)
        {
            return await _identityUnitOfWork.PlusClientRepository.GetById(id);
        }
        public async Task<int> Insert(Client client)
        {
           return await _identityUnitOfWork.PlusClientRepository.Insert(client);
        }
        public async Task<int> Update(Client client)
        {
           return await _identityUnitOfWork.PlusClientRepository.Update(client);
        }
        public async Task Delete(int id)
        {
            await DeleteCorsOrigin(id);
            await DeleteGrantType(id);
            await DeletePostLogoutRedirectUris(id);
            await DeleteRedirectUri(id);
            await DeleteRestrictions(id);
            await DeleteScopes(id);
            await DeleteSecrets(id);
            await DeleteClaims(id);
            await DeleteProperties(id);
            await _identityUnitOfWork.PlusClientRepository.Delete(id);

        }

        #region Scope
        public async Task<IEnumerable<ClientScope>> GetScopesByClientId(int clientId)
        {
           return  await _identityUnitOfWork.PlusClientScopeRepository.GetScopesByClientId(clientId);
            
        }

        public async Task AddScope(ClientScope clientScope)
        {
           await _identityUnitOfWork.PlusClientScopeRepository.Insert(clientScope);
        }

        public async Task UpdateScope(ClientScope clientScope)
        {
          await _identityUnitOfWork.PlusClientScopeRepository.Update(clientScope);
        }

        private async Task DeleteScopes(int clientId)
        {
           await _identityUnitOfWork.PlusClientScopeRepository.DeleteAll(clientId);
        }
        #endregion
        #region Secret
        public async Task<IEnumerable<ClientSecret>> GetSecretsByClientId(int clientId)
        {
            return await _identityUnitOfWork.PlusClientSecretRepository.GetSecretsByClientId(clientId);
        }

        public async Task AddSecret(ClientSecret clientSecret)
        {
           await _identityUnitOfWork.PlusClientSecretRepository.Insert(clientSecret);
        }

        public async Task UpdateSecret(ClientSecret clientSecret)
        {
           await _identityUnitOfWork.PlusClientSecretRepository.Update(clientSecret);
        }

        private async Task DeleteSecrets(int clientId)
        {
            await _identityUnitOfWork.PlusClientSecretRepository.DeleteAll(clientId);
        }
        #endregion
        #region Property
        public async Task<IEnumerable<ClientProperty>> GetPropertiesByClientId(int clientId)
        {
            return await _identityUnitOfWork.PlusClientPropertyRepository.GetPropertiesByClientId(clientId);
        }

        public async Task AddProperty(ClientProperty clientProperty)
        {
           await _identityUnitOfWork.PlusClientPropertyRepository.Insert(clientProperty);
        }

        public async Task UpdateProperty(ClientProperty clientProperty)
        {
           await _identityUnitOfWork.PlusClientPropertyRepository.Update(clientProperty);
        }

        private async Task DeleteProperties(int clientId)
        {
           await _identityUnitOfWork.PlusClientPropertyRepository.DeleteAll(clientId);
        }
        #endregion
        #region Claim
        public async  Task<IEnumerable<ClientClaim>> GetClaimsByClientId(int clientId)
        {
            return await _identityUnitOfWork.PlusClientClaimRepository.GetClaimsByClientId(clientId);
        }

        public async Task AddClaim(ClientClaim clientClaim)
        {
           await _identityUnitOfWork.PlusClientClaimRepository.Insert(clientClaim);
        }

        public async Task UpdateClaim(ClientClaim clientClaim)
        {
           await _identityUnitOfWork.PlusClientClaimRepository.Update(clientClaim);
        }

        private async Task DeleteClaims(int clientId)
        {
           await _identityUnitOfWork.PlusClientClaimRepository.DeleteAll(clientId);
        }
        #endregion
        #region RedirectUri
        public async Task<IEnumerable<ClientRedirectUri>> GetRedirectUriByClientId(int clientId)
        {
            return await _identityUnitOfWork.PlusClientRedirectUriRepository.GetRedirectUriByClientId(clientId);
        }

        public async Task AddRedirectUri(ClientRedirectUri clientRedirectUri)
        {
            await _identityUnitOfWork.PlusClientRedirectUriRepository.Insert(clientRedirectUri);
        }

        public async Task UpdateRedirectUri(ClientRedirectUri clientRedirectUri)
        {
            await _identityUnitOfWork.PlusClientRedirectUriRepository.Update(clientRedirectUri);
        }

        private async Task DeleteRedirectUri(int clientId)
        {
           await _identityUnitOfWork.PlusClientRedirectUriRepository.DeleteAll(clientId);
        }
        #endregion
        #region PostLogoutRedirectUri
        public async Task<IEnumerable<ClientPostLogoutRedirectUri>> GetPostLogoutRedirectUrisByClientId(int clientId)
        {
            return await _identityUnitOfWork.PlusClientPostLogoutRedirectUriRepository
                .GetPostLogoutRedirectUrisByClientId(clientId);
        }

        public async Task AddPostLogoutRedirectUri(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri)
        {
            await _identityUnitOfWork.PlusClientPostLogoutRedirectUriRepository.Insert(clientPostLogoutRedirectUri);
        }

        public async Task UpdatePostLogoutRedirectUri(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri)
        {
            await _identityUnitOfWork.PlusClientPostLogoutRedirectUriRepository.Update(clientPostLogoutRedirectUri);
        }

        private async Task DeletePostLogoutRedirectUris(int clientId)
        {
           await _identityUnitOfWork.PlusClientPostLogoutRedirectUriRepository.DeleteAll(clientId);
        }
        #endregion
        #region Restriction
        public async Task<IEnumerable<ClientIdPRestriction>> GetClientIdPRestrictionsByClientId(int clientId)
        {
            return await _identityUnitOfWork.PlusClientIdPRestrictionRepository.GetClientIdPRestrictionsByClientId(clientId);
        }

        public async Task AddRestriction(ClientIdPRestriction clientIdPRestriction)
        {
            await _identityUnitOfWork.PlusClientIdPRestrictionRepository.Insert(clientIdPRestriction);
        }

        public async Task UpdateRestriction(ClientIdPRestriction clientIdPRestriction)
        {
            await _identityUnitOfWork.PlusClientIdPRestrictionRepository.Insert(clientIdPRestriction);
        }

        private async Task DeleteRestrictions(int clientId)
        {
           await _identityUnitOfWork.PlusClientIdPRestrictionRepository.DeleteAll(clientId);
        }
        #endregion
        #region GrantType
        public async Task<IEnumerable<ClientGrantType>> GetGrantTypesByClientId(int clientId)
        {
            return await _identityUnitOfWork.PlusClientGrantTypeRepository.GetGrantTypesByClientId(clientId);
        }

        public async Task AddGrantType(ClientGrantType clientGrantType)
        {
           await _identityUnitOfWork.PlusClientGrantTypeRepository.Insert(clientGrantType);
        }

        public async Task UpdateGrantType(ClientGrantType clientGrantType)
        {
            await _identityUnitOfWork.PlusClientGrantTypeRepository.Update(clientGrantType);
        }

        private async Task DeleteGrantType(int clientId)
        {
           await _identityUnitOfWork.PlusClientGrantTypeRepository.DeleteAll(clientId);
        }
        #endregion
        #region
        public async Task<IEnumerable<ClientCorsOrigin>> GetCorsOriginsByClientId(int clientId)
        {
            return await _identityUnitOfWork.PlusClientCorsOriginRepository.GetCorsOriginByClientId(clientId);
        }

        public async Task AddCorsOrigin(ClientCorsOrigin clientCorsOrigin)
        {
            await _identityUnitOfWork.PlusClientCorsOriginRepository.Insert(clientCorsOrigin);
        }

        public async Task UpdateCorsOrigin(ClientCorsOrigin clientCorsOrigin)
        {
            await _identityUnitOfWork.PlusClientCorsOriginRepository.Update(clientCorsOrigin);
        }

        private async Task DeleteCorsOrigin(int clientId)
        {
           await _identityUnitOfWork.PlusClientCorsOriginRepository.DeleteAll(clientId);
        }

        #endregion
    }
}
