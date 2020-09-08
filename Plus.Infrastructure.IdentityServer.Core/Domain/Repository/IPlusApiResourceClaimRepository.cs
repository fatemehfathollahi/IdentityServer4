using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Domain.Repository
{
    public interface IPlusApiResourceClaimRepository 
    {
        void Insert(ApiResourceClaim apiClaim);

        void Update(ApiResourceClaim apiClaim);

        void DeleteAll(int resourceId);

        void Delete(int claimId);

        ApiResourceClaim GetById(int claimId);

        IEnumerable<ApiResourceClaim> GetAll();

        IEnumerable<ApiResourceClaim> GetClaimsByResourceId(int resourceId);
    }
}
