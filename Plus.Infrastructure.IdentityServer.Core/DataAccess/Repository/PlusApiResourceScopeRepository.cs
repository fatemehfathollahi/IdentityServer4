using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusApiResourceScopeRepository : IPlusApiResourceScopeRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourceScopeRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public async Task<ApiResourceScope> GetById(int scopeId)
        {
            var _entity = _plusDataContext.ApiResourceScopes.AsNoTracking().FirstOrDefault(r => r.Id.Equals(scopeId));
            return _entity.ToModel();
        }

        public async Task<IEnumerable<ApiResourceScope>> GetScopesByResourceId(int resourceId)
        {
            var _entityList = _plusDataContext.ApiResourceScopes.Where
                (s => s.ApiResourceId.Equals(resourceId)).ToList();
            return _entityList.ToModel();
        }

        public async Task Insert(ApiResourceScope apiScope)
        {
            var _entity = apiScope.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResourceScopes.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(ApiResourceScope apiScope)
        {
            var _entity = apiScope.ToEntity();
            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
      
        public async Task DeleteAll(int resourceId)
        {
            var _scopes = GetScopesByResourceId(resourceId).Result;
            _scopes.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ApiResourceScopes.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public async Task Delete(int scopeId)
        {
            var _entity = _plusDataContext.ApiResourceScopes.Find(scopeId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ApiResourceScopes.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task<IEnumerable<ApiResourceScope>> GetAll()
        {
            var _entityList = _plusDataContext.ApiResourceScopes.ToList();
            return _entityList.ToModel();
        }
    }
}
