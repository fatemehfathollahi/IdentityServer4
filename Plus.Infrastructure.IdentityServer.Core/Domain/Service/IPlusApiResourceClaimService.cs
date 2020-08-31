using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusApiResourceClaimService
    {
        void Insert(int resourceId, ApiResourceClaim apiClaim);

        void Update(int resourceId, ApiResourceClaim apiClaim);

        void Delete(int resourceId, int claimId);

        ApiResourceClaim GetById(int resourceId, int claimId);

        IEnumerable<ApiResourceClaim> GetClaimsByResourceId(int resourceId);
    }
}
