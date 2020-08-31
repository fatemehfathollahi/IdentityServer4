using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusApiResourceScopeRepository : IPlusApiResourceScopeRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourceScopeRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public ApiResourceScope GetById(int resourceId,int scopeId)
        {
            var _entity = _plusDataContext.ApiResources
                .Single(r => r.Id.Equals(resourceId)).Scopes
                .Single(s => s.Id.Equals(scopeId)); 
            return _entity.ToModel();
        }

        public IEnumerable<ApiResourceScope> GetScopesByResourceId(int resourceId)
        {
            var _entityList = _plusDataContext.ApiResources
               .Single(r => r.Id.Equals(resourceId)).Scopes.ToList();
            return _entityList.ToModel();
        }

        public void Insert(int resourceId,ApiResourceScope apiScope)
        {
            var _entity = apiScope.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Scopes.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(int resourceId, ApiResourceScope apiScope)
        {
            var _entity = apiScope.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
             Delete(resourceId, apiScope.Id);
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Scopes.Add(_entity);
            _plusDataContext.SaveChanges();
        }
        public void Delete(int resourceId,int scopeId)
        {
            var _entity = _plusDataContext.ApiResources
              .Single(r => r.Id.Equals(resourceId)).Scopes
              .Single(s => s.Id.Equals(scopeId));
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Scopes.Remove(_entity); 
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
