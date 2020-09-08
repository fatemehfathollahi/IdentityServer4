using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusClientScopeRepository : IPlusClientScopeRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientScopeRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public IEnumerable<ClientScope> GetAll()
        {
            var _entityList = _plusDataContext.ClientScopes.ToList();
            return _entityList.ToModel();
        }

        public ClientScope GetById(int scopeId)
        {
            var _entity = _plusDataContext.ClientScopes.AsNoTracking().FirstOrDefault(r => r.Id.Equals(scopeId));
            return _entity.ToModel();
        }

        public IEnumerable<ClientScope> GetScopesByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientScopes.Where
               (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel();
        }

        public void Insert(ClientScope clientScope)
        {
            var _entity = clientScope.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientScopes.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(ClientScope clientScope)
        {
            var _entity = clientScope.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }

        public void Delete(int scopeId)
        {
            var _entity = _plusDataContext.ClientScopes.Find(scopeId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientScopes.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public void DeleteAll(int clientId)
        {
            var _scopes = GetScopesByClientId(clientId);
            _scopes.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientScopes.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }
    }
}
