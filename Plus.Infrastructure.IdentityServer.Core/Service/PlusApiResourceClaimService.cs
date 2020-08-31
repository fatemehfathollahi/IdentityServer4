using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.Service
{
    public class PlusApiResourceClaimService : IPlusApiResourceClaimService
    {
        private readonly IPlusApiResourceClaimRepository _apiResoureClaimRepository;

        public PlusApiResourceClaimService(IPlusApiResourceClaimRepository apiClaimRepository)
        {
            _apiResoureClaimRepository = apiClaimRepository;
        }

        public ApiResourceClaim GetById(int resourceId, int claimId)
        {
            return _apiResoureClaimRepository.GetById(resourceId, claimId);
        }

        public IEnumerable<ApiResourceClaim> GetClaimsByResourceId(int resourceId)
        {
            return _apiResoureClaimRepository.GetClaimsByResourceId(resourceId);
        }

        public void Insert(int resourceId, ApiResourceClaim apiClaim)
        {
            _apiResoureClaimRepository.Insert(resourceId, apiClaim);
        }

        public void Update(int resourceId, ApiResourceClaim apiClaim)
        {
            _apiResoureClaimRepository.Update(resourceId, apiClaim);
        }

        public void Delete(int resourceId, int claimId)
        {
            _apiResoureClaimRepository.Delete(resourceId, claimId);
        }

    }
}
