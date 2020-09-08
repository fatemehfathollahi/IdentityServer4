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

        public ApiResourceClaim GetById(int claimId)
        {
            return _apiResoureClaimRepository.GetById(claimId);
        }

        public IEnumerable<ApiResourceClaim> GetClaimsByResourceId(int resourceId)
        {
            return _apiResoureClaimRepository.GetClaimsByResourceId(resourceId);
        }

        public void Insert(ApiResourceClaim apiClaim)
        {
            _apiResoureClaimRepository.Insert(apiClaim);
        }

        public void Update(ApiResourceClaim apiClaim)
        {
            _apiResoureClaimRepository.Update(apiClaim);
        }

        public void Delete(int claimId)
        {
            _apiResoureClaimRepository.Delete(claimId);
        }

        public void DeleteAll(int resourceId)
        {
            _apiResoureClaimRepository.DeleteAll(resourceId);
        }

        public IEnumerable<ApiResourceClaim> GetAll()
        {
           return _apiResoureClaimRepository.GetAll();
        }
    }
}
