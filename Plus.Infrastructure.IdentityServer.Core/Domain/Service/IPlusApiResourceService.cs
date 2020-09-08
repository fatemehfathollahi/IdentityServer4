using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
  
    public interface IPlusApiResourceService
    {
        int Insert(ApiResource apiResource);
        int Update(ApiResource apiResource);
        int Delete(int id);
        ApiResource GetById(int id);
        IEnumerable<ApiResource> GetAll();

        void AddScope(ApiResourceScope apiScope);
        void UpdateScope(ApiResourceScope apiScope);
        IEnumerable<ApiResourceScope> GetScopesByResourceId(int resourceId);

        void AddClaim(ApiResourceClaim apiClaim);
        void UpdateClaim(ApiResourceClaim apiClaim);
        IEnumerable<ApiResourceClaim> GetClaimsByResourceId(int resourceId);

        void AddProperty(ApiResourceProperty apiProperty);
        void UpdateProperty(ApiResourceProperty apiProperty);
        IEnumerable<ApiResourceProperty> GetPropertiesByResourceId(int resourceId);

        void AddSecret(ApiResourceSecret apiSecret);
        void UpdateSecret(ApiResourceSecret apiSecret);
        IEnumerable<ApiResourceSecret> GetSecretsByResourceId(int resourceId);

    }

}