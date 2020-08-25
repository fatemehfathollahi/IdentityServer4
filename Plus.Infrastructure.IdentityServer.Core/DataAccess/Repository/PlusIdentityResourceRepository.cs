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
    public class PlusIdentityResourceRepository : IPlusIdentityResourceRepository
    {
        private readonly PlusConfigurationDbContext plusDataContext;
        public PlusIdentityResourceRepository(PlusConfigurationDbContext plusDataContext)
        {
            this.plusDataContext = plusDataContext;
        }

        public IEnumerable<IdentityResource> GetAll()
        {
            var _entityList = plusDataContext.IdentityResources.ToList();
            return _entityList.ToModel();
        }

        public IdentityResource GetById(int id)
        {
            var _entity = plusDataContext.IdentityResources.Find(id);
            return _entity.ToModel();
        }

        public void Insert(IdentityResource identityResource)
        {
            var _entity = identityResource.ToEntity();
            plusDataContext.Entry(_entity).State = EntityState.Added;
            plusDataContext.IdentityResources.Add(_entity);
            plusDataContext.SaveChanges();
        }

        public void Update(IdentityResource identityResource)
        {
            var _entity = identityResource.ToEntity();
            // plusDataContext.Entry(_entity).State = EntityState.Detached;
            plusDataContext.Entry(_entity).State = EntityState.Modified;
             plusDataContext.IdentityResources.Update(_entity);
            plusDataContext.SaveChanges();
        }
    }
}
