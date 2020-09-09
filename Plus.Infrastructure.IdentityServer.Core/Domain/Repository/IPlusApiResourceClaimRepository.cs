using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceClaimRepository 
    {
        Task Insert(ApiResourceClaim apiClaim);

        Task Update(ApiResourceClaim apiClaim);

        Task DeleteAll(int resourceId);

        Task Delete(int claimId);

        Task<ApiResourceClaim> GetById(int claimId);

        Task<IEnumerable<ApiResourceClaim>> GetAll();

        Task<IEnumerable<ApiResourceClaim>> GetClaimsByResourceId(int resourceId);
    }
}
