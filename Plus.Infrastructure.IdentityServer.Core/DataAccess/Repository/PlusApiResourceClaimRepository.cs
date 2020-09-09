using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusApiResourceClaimRepository : IPlusApiResourceClaimRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourceClaimRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public async Task<ApiResourceClaim> GetById(int claimId)
        {
            var _entity = _plusDataContext.ApiResourceClaims.Find(claimId);
            return _entity.ToModel();
        }

        public async Task<IEnumerable<ApiResourceClaim>> GetClaimsByResourceId(int resourceId)
        {
            var _entityList = _plusDataContext.ApiResourceClaims.Where
                 (s => s.ApiResourceId.Equals(resourceId)).ToList();
            return _entityList.ToModel();
        }

        public async Task Insert(ApiResourceClaim apiClaim)
        {
            var _entity = apiClaim.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResourceClaims.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(ApiResourceClaim apiClaim)
        {
            var _entity = apiClaim.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }

        public async Task DeleteAll(int resourceId)
        {
            var _scopes = GetClaimsByResourceId(resourceId).Result;
            _scopes.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ApiResourceClaims.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public async Task Delete(int claimId)
        {
            var _entity = _plusDataContext.ApiResourceSecrets.Find(claimId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ApiResourceSecrets.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task<IEnumerable<ApiResourceClaim>> GetAll()
        {
            var _entityList = _plusDataContext.ApiResourceClaims.ToList();
            return _entityList.ToModel();
        }
    }
}
