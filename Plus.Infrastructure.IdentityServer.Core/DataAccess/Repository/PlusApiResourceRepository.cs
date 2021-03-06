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
    public class PlusApiResourceRepository : IPlusApiResourceRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourceRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }
        
        public async Task<IEnumerable<ApiResource>> GetAll()
        {
            var _entityList = _plusDataContext.ApiResources.Include(r => r.Scopes)
                .Include(r => r.Secrets).Include(r => r.Properties).Include(r => r.UserClaims).ToList();
            return _entityList.ToModel();
        }

        public async Task<ApiResource> GetById(int id)
        {
            var _entity =  GetAll().Result.Where(r => r.Id.Equals(id)).FirstOrDefault();
            return _entity;
        }

        public async Task<int> Insert(ApiResource apiResource)
        {
            var _entity = apiResource.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResources.Add(_entity);
            _plusDataContext.SaveChanges();
            return _entity.Id;
        }

        public async Task<int> Update(ApiResource apiResource)
        {
            var _entity = apiResource.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.ApiResources.Update(_entity);
            _plusDataContext.SaveChanges();
            return _entity.Id;
        }
        public async Task Delete(int id)
        {
            var _entity = _plusDataContext.ApiResources.Find(id);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ApiResources.Remove(_entity);
            _plusDataContext.SaveChanges();
        }
    }
}
