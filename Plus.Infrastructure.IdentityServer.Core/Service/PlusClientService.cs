using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusClientService : IPlusClientService
    {
        private readonly IIdentityUnitOfWork _identityUnitOfWork;
        public PlusClientService(IIdentityUnitOfWork identityUnitOfWork)
        {
            _identityUnitOfWork = identityUnitOfWork;
        }

        public IEnumerable<Client> GetAll()
        {
           return _identityUnitOfWork.PlusClientRepository.GetAll();
        }
        public Client GetById(int id)
        {
            return _identityUnitOfWork.PlusClientRepository.GetById(id);
        }
        public int Insert(Client client)
        {
           return _identityUnitOfWork.PlusClientRepository.Insert(client);
        }
        public int Update(Client client)
        {
           return _identityUnitOfWork.PlusClientRepository.Update(client);
        }
        public int Delete(int id)
        {
            DeleteCorsOrigin(id);
            DeleteGrantType(id);
            DeletePostLogoutRedirectUris(id);
            DeleteRedirectUri(id);
            DeleteRestrictions(id);
            DeleteScopes(id);
            DeleteSecrets(id);
            DeleteClaims(id);
            DeleteProperties(id);
            return _identityUnitOfWork.PlusClientRepository.Delete(id);

        }

        #region Scope
        public IEnumerable<ClientScope> GetScopesByClientId(int clientId)
        {
           return  _identityUnitOfWork.PlusClientScopeRepository.GetScopesByClientId(clientId);
            
        }

        public void AddScope(ClientScope clientScope)
        {
            _identityUnitOfWork.PlusClientScopeRepository.Insert(clientScope);
        }

        public void UpdateScope(ClientScope clientScope)
        {
            _identityUnitOfWork.PlusClientScopeRepository.Update(clientScope);
        }

        private void DeleteScopes(int clientId)
        {
            _identityUnitOfWork.PlusClientScopeRepository.DeleteAll(clientId);
        }
        #endregion
        #region Secret
        public IEnumerable<ClientSecret> GetSecretsByClientId(int clientId)
        {
            return _identityUnitOfWork.PlusClientSecretRepository.GetSecretsByClientId(clientId);
        }

        public void AddSecret(ClientSecret clientSecret)
        {
            _identityUnitOfWork.PlusClientSecretRepository.Insert(clientSecret);
        }

        public void UpdateSecret(ClientSecret clientSecret)
        {
            _identityUnitOfWork.PlusClientSecretRepository.Update(clientSecret);
        }

        private void DeleteSecrets(int clientId)
        {
            _identityUnitOfWork.PlusClientSecretRepository.DeleteAll(clientId);
        }
        #endregion
        #region Property
        public IEnumerable<ClientProperty> GetPropertiesByClientId(int clientId)
        {
            return _identityUnitOfWork.PlusClientPropertyRepository.GetPropertiesByClientId(clientId);
        }

        public void AddProperty(ClientProperty clientProperty)
        {
            _identityUnitOfWork.PlusClientPropertyRepository.Insert(clientProperty);
        }

        public void UpdateProperty(ClientProperty clientProperty)
        {
            _identityUnitOfWork.PlusClientPropertyRepository.Update(clientProperty);
        }

        private void DeleteProperties(int clientId)
        {
            _identityUnitOfWork.PlusClientPropertyRepository.DeleteAll(clientId);
        }
        #endregion
        #region Claim
        public IEnumerable<ClientClaim> GetClaimsByClientId(int clientId)
        {
            return _identityUnitOfWork.PlusClientClaimRepository.GetClaimsByClientId(clientId);
        }

        public void AddClaim(ClientClaim clientClaim)
        {
            _identityUnitOfWork.PlusClientClaimRepository.Insert(clientClaim);
        }

        public void UpdateClaim(ClientClaim clientClaim)
        {
            _identityUnitOfWork.PlusClientClaimRepository.Update(clientClaim);
        }

        private void DeleteClaims(int clientId)
        {
            _identityUnitOfWork.PlusClientClaimRepository.DeleteAll(clientId);
        }
        #endregion
        #region RedirectUri
        public IEnumerable<ClientRedirectUri> GetRedirectUriByClientId(int clientId)
        {
            return _identityUnitOfWork.PlusClientRedirectUriRepository.GetRedirectUriByClientId(clientId);
        }

        public void AddRedirectUri(ClientRedirectUri clientRedirectUri)
        {
            throw new NotImplementedException();
        }

        public void UpdateRedirectUri(ClientRedirectUri clientRedirectUri)
        {
            throw new NotImplementedException();
        }

        private void DeleteRedirectUri(int clientId)
        {
            _identityUnitOfWork.PlusClientRedirectUriRepository.DeleteAll(clientId);
        }
        #endregion
        #region PostLogoutRedirectUri
        public IEnumerable<ClientPostLogoutRedirectUri> GetPostLogoutRedirectUrisByClientId(int clientId)
        {
            return _identityUnitOfWork.PlusClientPostLogoutRedirectUriRepository.GetPostLogoutRedirectUrisByClientId(clientId);
        }

        public void AddPostLogoutRedirectUri(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri)
        {
            throw new NotImplementedException();
        }

        public void UpdatePostLogoutRedirectUri(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri)
        {
            throw new NotImplementedException();
        }

        private void DeletePostLogoutRedirectUris(int clientId)
        {
            _identityUnitOfWork.PlusClientPostLogoutRedirectUriRepository.DeleteAll(clientId);
        }
        #endregion
        #region Restriction
        public IEnumerable<ClientIdPRestriction> GetClientIdPRestrictionsByClientId(int clientId)
        {
            return _identityUnitOfWork.PlusClientIdPRestrictionRepository.GetClientIdPRestrictionsByClientId(clientId);
        }

        public void AddRestriction(ClientIdPRestriction clientIdPRestriction)
        {
            throw new NotImplementedException();
        }

        public void UpdateRestriction(ClientIdPRestriction clientIdPRestriction)
        {
            throw new NotImplementedException();
        }

        private void DeleteRestrictions(int clientId)
        {
            _identityUnitOfWork.PlusClientIdPRestrictionRepository.DeleteAll(clientId);
        }
        #endregion
        #region GrantType
        public IEnumerable<ClientGrantType> GetGrantTypesByClientId(int clientId)
        {
            return _identityUnitOfWork.PlusClientGrantTypeRepository.GetGrantTypesByClientId(clientId);
        }

        public void AddGrantType(ClientGrantType clientGrantType)
        {
            throw new NotImplementedException();
        }

        public void UpdateGrantType(ClientGrantType clientGrantType)
        {
            throw new NotImplementedException();
        }

        private void DeleteGrantType(int clientId)
        {
            _identityUnitOfWork.PlusClientGrantTypeRepository.DeleteAll(clientId);
        }
        #endregion
        #region
        public IEnumerable<ClientCorsOrigin> GetCorsOriginsByClientId(int clientId)
        {
            return _identityUnitOfWork.PlusClientCorsOriginRepository.GetCorsOriginByClientId(clientId);
        }

        public void AddCorsOrigin(ClientCorsOrigin clientCorsOrigin)
        {
            throw new NotImplementedException();
        }

        public void UpdateCorsOrigin(ClientCorsOrigin clientCorsOrigin)
        {
            throw new NotImplementedException();
        }

        private void DeleteCorsOrigin(int clientId)
        {
            _identityUnitOfWork.PlusClientCorsOriginRepository.DeleteAll(clientId);
        }

        #endregion
    }
}
