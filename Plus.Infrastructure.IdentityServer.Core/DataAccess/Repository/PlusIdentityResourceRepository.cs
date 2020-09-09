using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusIdentityResourceRepository : IPlusIdentityResourceRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusIdentityResourceRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public async Task<IEnumerable<IdentityResource>> GetAll()
        {
            var _entityList = _plusDataContext.IdentityResources.ToList();
            return  _entityList.ToModel();
        }

        public async Task<IdentityResource> GetById(int id)
        {
            var _entity = _plusDataContext.IdentityResources.Find(id);
            return _entity.ToModel();
        }

        public async Task Insert(IdentityResource identityResource)
        {
            var _entity = identityResource.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.IdentityResources.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(IdentityResource identityResource)
        {
            var _entity = identityResource.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
             _plusDataContext.IdentityResources.Update(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var _entity = _plusDataContext.IdentityResources.Find(id);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.IdentityResources.Remove(_entity);
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
