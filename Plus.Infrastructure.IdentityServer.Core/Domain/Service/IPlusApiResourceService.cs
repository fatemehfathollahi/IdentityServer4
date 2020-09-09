using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
  
    public interface IPlusApiResourceService
    {
        Task<int> Insert(ApiResource apiResource);
        Task<int> Update(ApiResource apiResource);
        Task Delete(int id);
        Task<ApiResource> GetById(int id);
        Task<IEnumerable<ApiResource>> GetAll();

        Task AddScope(ApiResourceScope apiScope);
        Task UpdateScope(ApiResourceScope apiScope);
        Task<IEnumerable<ApiResourceScope>> GetScopesByResourceId(int resourceId);

        Task AddClaim(ApiResourceClaim apiClaim);
        Task UpdateClaim(ApiResourceClaim apiClaim);
        Task<IEnumerable<ApiResourceClaim>> GetClaimsByResourceId(int resourceId);

        Task AddProperty(ApiResourceProperty apiProperty);
        Task UpdateProperty(ApiResourceProperty apiProperty);
        Task<IEnumerable<ApiResourceProperty>> GetPropertiesByResourceId(int resourceId);

        Task AddSecret(ApiResourceSecret apiSecret);
        Task UpdateSecret(ApiResourceSecret apiSecret);
        Task<IEnumerable<ApiResourceSecret>> GetSecretsByResourceId(int resourceId);

    }

}