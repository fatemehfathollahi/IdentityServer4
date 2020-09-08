using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusApiResourceService : IPlusApiResourceService
    {
        private readonly IIdentityUnitOfWork _identityUnitOfWork;
        public PlusApiResourceService(IIdentityUnitOfWork identityUnitOfWork)
        {
            _identityUnitOfWork = identityUnitOfWork;
        }

        public IEnumerable<ApiResource> GetAll()
        {
            return _identityUnitOfWork.PlusApiResourceRepository.GetAll();
        }
        public ApiResource GetById(int id)
        {
            return _identityUnitOfWork.PlusApiResourceRepository.GetById(id);
        }
        public int Insert(ApiResource apiResource)
        {
            return _identityUnitOfWork.PlusApiResourceRepository.Insert(apiResource);
        }
        public int Update(ApiResource apiResource)
        {
            return _identityUnitOfWork.PlusApiResourceRepository.Update(apiResource);
        }
        public int Delete(int id)
        {
            DeleteScopes(id);
            DeleteSecrets(id);
            DeleteClaims(id);
            DeleteProperties(id);
            return _identityUnitOfWork.PlusApiResourceRepository.Delete(id);
        }

        #region Scope
        public void AddScope(ApiResourceScope apiScope)
        {
            _identityUnitOfWork.PlusApiResourceScopeRepository.Insert(apiScope);
        }
        public void UpdateScope(ApiResourceScope apiScope)
        {
            _identityUnitOfWork.PlusApiResourceScopeRepository.Update(apiScope);
        }
        public IEnumerable<ApiResourceScope> GetScopesByResourceId(int resourceId)
        {
            return _identityUnitOfWork.PlusApiResourceScopeRepository.GetScopesByResourceId(resourceId);
        }
        private void DeleteScopes(int resourceId)
        {
            _identityUnitOfWork.PlusApiResourceScopeRepository.DeleteAll(resourceId);
        }
        #endregion
        #region Claim
        public void AddClaim(ApiResourceClaim apiClaim)
        {
            _identityUnitOfWork.PlusApiResourceClaimRepository.Insert(apiClaim);
        }
        public void UpdateClaim(ApiResourceClaim apiClaim)
        {
            _identityUnitOfWork.PlusApiResourceClaimRepository.Update(apiClaim);
        }
        public IEnumerable<ApiResourceClaim> GetClaimsByResourceId(int resourceId)
        {
            return _identityUnitOfWork.PlusApiResourceClaimRepository.GetClaimsByResourceId(resourceId);
        }
        private void DeleteClaims(int resourceId)
        {
            _identityUnitOfWork.PlusApiResourceClaimRepository.DeleteAll(resourceId);
        }
        #endregion
        #region Property
        public void AddProperty(ApiResourceProperty apiProperty)
        {
            _identityUnitOfWork.PlusApiResourcePropertyRepository.Insert(apiProperty);
        }
        public void UpdateProperty(ApiResourceProperty apiProperty)
        {
            _identityUnitOfWork.PlusApiResourcePropertyRepository.Update(apiProperty);
        }
        public IEnumerable<ApiResourceProperty> GetPropertiesByResourceId(int resourceId)
        {
            return _identityUnitOfWork.PlusApiResourcePropertyRepository.GetPropertiesByResourceId(resourceId);
        }
        private void DeleteProperties(int resourceId)
        {
            _identityUnitOfWork.PlusApiResourcePropertyRepository.DeleteAll(resourceId);
        }
        #endregion
        #region secret
        public void AddSecret(ApiResourceSecret apiSecret)
        {
            _identityUnitOfWork.PlusApiResourceSecretRepository.Insert(apiSecret);
        }
        public void UpdateSecret(ApiResourceSecret apiSecret)
        {
            _identityUnitOfWork.PlusApiResourceSecretRepository.Update(apiSecret);
        }
        public IEnumerable<ApiResourceSecret> GetSecretsByResourceId(int resourceId)
        {
            return _identityUnitOfWork.PlusApiResourceSecretRepository.GetSecretsByResourceId(resourceId);
        }
        private void DeleteSecrets(int resourceId)
        {
            _identityUnitOfWork.PlusApiResourceSecretRepository.DeleteAll(resourceId);
        }
        #endregion
    }
}
