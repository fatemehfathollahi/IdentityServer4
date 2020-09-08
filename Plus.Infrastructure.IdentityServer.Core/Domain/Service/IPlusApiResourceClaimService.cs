using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Service
{
    public interface IPlusApiResourceClaimService
    {
        void Insert(ApiResourceClaim apiClaim);

        void Update(ApiResourceClaim apiClaim);

        void Delete(int claimId);

        void DeleteAll(int resourceId);

        ApiResourceClaim GetById(int claimId);

        IEnumerable<ApiResourceClaim> GetClaimsByResourceId(int resourceId);

        IEnumerable<ApiResourceClaim> GetAll();
    }
}
