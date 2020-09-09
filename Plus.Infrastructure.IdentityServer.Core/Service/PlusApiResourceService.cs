using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusApiResourceService : IPlusApiResourceService
    {
        private readonly IIdentityUnitOfWork _identityUnitOfWork;
        public PlusApiResourceService(IIdentityUnitOfWork identityUnitOfWork)
        {
            _identityUnitOfWork = identityUnitOfWork;
        }

        public async Task<IEnumerable<ApiResource>> GetAll()
        {
            return await _identityUnitOfWork.PlusApiResourceRepository.GetAll();
        }
        public async Task<ApiResource> GetById(int id)
        {
            return await _identityUnitOfWork.PlusApiResourceRepository.GetById(id);
        }
        public async Task<int> Insert(ApiResource apiResource)
        {
            return await _identityUnitOfWork.PlusApiResourceRepository.Insert(apiResource);
        }
        public async Task<int> Update(ApiResource apiResource)
        {
            return await _identityUnitOfWork.PlusApiResourceRepository.Update(apiResource);
        }
        public async Task Delete(int id)
        {
           await DeleteScopes(id);
           await DeleteSecrets(id);
           await DeleteClaims(id);
           await DeleteProperties(id);
           await _identityUnitOfWork.PlusApiResourceRepository.Delete(id);
        }

        #region Scope
        public async Task AddScope(ApiResourceScope apiScope)
        {
           await _identityUnitOfWork.PlusApiResourceScopeRepository.Insert(apiScope);
        }
        public async Task UpdateScope(ApiResourceScope apiScope)
        {
            await _identityUnitOfWork.PlusApiResourceScopeRepository.Update(apiScope);
        }
        public async Task<IEnumerable<ApiResourceScope>> GetScopesByResourceId(int resourceId)
        {
            return await _identityUnitOfWork.PlusApiResourceScopeRepository.GetScopesByResourceId(resourceId);
        }
        private async Task DeleteScopes(int resourceId)
        {
            await _identityUnitOfWork.PlusApiResourceScopeRepository.DeleteAll(resourceId);
        }
        #endregion
        #region Claim
        public async Task AddClaim(ApiResourceClaim apiClaim)
        {
            await _identityUnitOfWork.PlusApiResourceClaimRepository.Insert(apiClaim);
        }
        public async Task UpdateClaim(ApiResourceClaim apiClaim)
        {
            await _identityUnitOfWork.PlusApiResourceClaimRepository.Update(apiClaim);
        }
        public async Task<IEnumerable<ApiResourceClaim>> GetClaimsByResourceId(int resourceId)
        {
            return await _identityUnitOfWork.PlusApiResourceClaimRepository.GetClaimsByResourceId(resourceId);
        }
        private async Task DeleteClaims(int resourceId)
        {
            await _identityUnitOfWork.PlusApiResourceClaimRepository.DeleteAll(resourceId);
        }
        #endregion
        #region Property
        public async Task AddProperty(ApiResourceProperty apiProperty)
        {
            await _identityUnitOfWork.PlusApiResourcePropertyRepository.Insert(apiProperty);
        }
        public async Task UpdateProperty(ApiResourceProperty apiProperty)
        {
            await _identityUnitOfWork.PlusApiResourcePropertyRepository.Update(apiProperty);
        }
        public async Task<IEnumerable<ApiResourceProperty>> GetPropertiesByResourceId(int resourceId)
        {
            return await _identityUnitOfWork.PlusApiResourcePropertyRepository.GetPropertiesByResourceId(resourceId);
        }
        private async Task DeleteProperties(int resourceId)
        {
            await _identityUnitOfWork.PlusApiResourcePropertyRepository.DeleteAll(resourceId);
        }
        #endregion
        #region secret
        public async Task AddSecret(ApiResourceSecret apiSecret)
        {
            await _identityUnitOfWork.PlusApiResourceSecretRepository.Insert(apiSecret);
        }
        public async Task UpdateSecret(ApiResourceSecret apiSecret)
        {
            await _identityUnitOfWork.PlusApiResourceSecretRepository.Update(apiSecret);
        }
        public async Task<IEnumerable<ApiResourceSecret>> GetSecretsByResourceId(int resourceId)
        {
            return await _identityUnitOfWork.PlusApiResourceSecretRepository.GetSecretsByResourceId(resourceId);
        }
        private async Task DeleteSecrets(int resourceId)
        {
            await _identityUnitOfWork.PlusApiResourceSecretRepository.DeleteAll(resourceId);
        }
        #endregion
    }
}
