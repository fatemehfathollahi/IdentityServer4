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
    public class PlusApiResourceSecretRepository : IPlusApiResourceSecretRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourceSecretRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public ApiResourceSecret GetById(int resourceId, int secretId)
        {
            var _entity = _plusDataContext.ApiResources
                .Single(r => r.Id.Equals(resourceId)).Secrets
                .Single(s => s.Id.Equals(secretId));
            return _entity.ToModel();
        }

        public IEnumerable<ApiResourceSecret> GetSecretsByResourceId(int resourceId)
        {
            var _entityList = _plusDataContext.ApiResources
              .Single(r => r.Id.Equals(resourceId)).Secrets.ToList();
            return _entityList.ToModel();
        }

        public void Insert(int resourceId, ApiResourceSecret apiSecret)
        {
            var _entity = apiSecret.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Secrets.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(int resourceId, ApiResourceSecret apiSecret)
        {
            var _entity = apiSecret.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            Delete(resourceId, apiSecret.Id);
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Secrets.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Delete(int resourceId, int secretId)
        {
            var _entity = _plusDataContext.ApiResources
             .Single(r => r.Id.Equals(resourceId)).Secrets
             .Single(s => s.Id.Equals(secretId));
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Secrets.Remove(_entity);
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
