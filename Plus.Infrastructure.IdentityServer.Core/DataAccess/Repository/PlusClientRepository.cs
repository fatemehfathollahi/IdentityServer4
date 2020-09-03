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
    public class PlusClientRepository : IPlusClientRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public IEnumerable<Client> GetAll()
        {
            var _entityList = _plusDataContext.Clients.ToList();
            return _entityList.ToModel();
        }

        public Client GetById(string id)
        {
            var _entity = _plusDataContext.Clients.Find(id);
            return _entity.ToModel();
        }

        public void Insert(Client client)
        {
            var _entity = client.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.Clients.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(Client client)
        {
            var _entity = client.ToEntity();
            // plusDataContext.Entry(_entity).State = EntityState.Detached;
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.Clients.Update(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var _entity = _plusDataContext.Clients.Find(id);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.Clients.Remove(_entity);
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
