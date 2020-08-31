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
    public class PlusApiResourcePropertyRepository : IPlusApiResourcePropertyRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourcePropertyRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public ApiResourceProperty GetById(int resourceId, int propertyId)
        {
            var _entity = _plusDataContext.ApiResources
                 .Single(r => r.Id.Equals(resourceId)).Properties
                 .Single(s => s.Id.Equals(propertyId));
            return _entity.ToModel();
        }

        public IEnumerable<ApiResourceProperty> GetPropertiesByResourceId(int resourceId)
        {
            var _entityList = _plusDataContext.ApiResources
             .Single(r => r.Id.Equals(resourceId)).Properties.ToList();
            return _entityList.ToModel();
        }

        public void Insert(int resourceId, ApiResourceProperty apiProperty)
        {
            var _entity = apiProperty.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Properties.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(int resourceId, ApiResourceProperty apiProperty)
        {
            var _entity = apiProperty.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            Delete(resourceId, apiProperty.Id);
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Properties.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Delete(int resourceId, int propertyId)
        {
            var _entity = _plusDataContext.ApiResources
           .Single(r => r.Id.Equals(resourceId)).Properties
           .Single(s => s.Id.Equals(propertyId));
            _plusDataContext.ApiResources.Single(r => r.Id.Equals(resourceId)).Properties.Remove(_entity);
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
