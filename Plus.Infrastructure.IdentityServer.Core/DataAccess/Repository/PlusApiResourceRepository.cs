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
    public class PlusApiResourceRepository : IPlusApiResourceRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourceRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }
        
        public IEnumerable<ApiResource> GetAll()
        {
            var _entityList = _plusDataContext.ApiResources.ToList();
            return _entityList.ToModel();
        }

        public ApiResource GetById(int id)
        {
            var _entity = _plusDataContext.ApiResources.Find(id);
            return _entity.ToModel();
        }

        public void Insert(ApiResource apiResource)
        {
            var _entity = apiResource.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResources.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(ApiResource apiResource)
        {
            var _entity = apiResource.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.ApiResources.Update(_entity);
            _plusDataContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var _entity = _plusDataContext.ApiResources.Find(id);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ApiResources.Remove(_entity);
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
