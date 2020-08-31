using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusApiResourceClaimRepository : IPlusApiResourceClaimRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourceClaimRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public ApiResourceClaim GetById(int resourceId, int claimId)
        {
            var _entity = _plusDataContext.ApiResources
                 .Single(r => r.Id.Equals(resourceId)).UserClaims
                 .Single(s => s.Id.Equals(claimId));
            return _entity.ToModel();
        }

        public IEnumerable<ApiResourceClaim> GetClaimsByResourceId(int resourceId)
        {
            var _entityList = _plusDataContext.ApiResources
             .Single(r => r.Id.Equals(resourceId)).UserClaims.ToList();
            return _entityList.ToModel();
        }

        public void Insert(int resourceId, ApiResourceClaim apiClaim)
        {
            var _entity = apiClaim.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).UserClaims.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(int resourceId, ApiResourceClaim apiClaim)
        {
            var _entity = apiClaim.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            Delete(resourceId, apiClaim.Id);
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).UserClaims.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Delete(int resourceId, int claimId)
        {
            var _entity = _plusDataContext.ApiResources
            .Single(r => r.Id.Equals(resourceId)).UserClaims
            .Single(s => s.Id.Equals(claimId));
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).UserClaims.Remove(_entity);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _plusDataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
