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
    public class PlusClientPostLogoutRedirectUriRepository : IPlusClientPostLogoutRedirectUriRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientPostLogoutRedirectUriRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public void Delete(int clientPostLogoutRedirectUriId)
        {
            var _entity = _plusDataContext.ClientPostLogoutRedirectUris.Find(clientPostLogoutRedirectUriId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientPostLogoutRedirectUris.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public void DeleteAll(int clientId)
        {
            var _redirectUris = GetPostLogoutRedirectUrisByClientId(clientId);
            _redirectUris.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientPostLogoutRedirectUris.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public IEnumerable<ClientPostLogoutRedirectUri> GetAll()
        {
            var _entityList = _plusDataContext.ClientPostLogoutRedirectUris.ToList();
            return _entityList.ToModel();
        }

        public ClientPostLogoutRedirectUri GetById(int clientPostLogoutRedirectUriId)
        {
            var _entity = _plusDataContext.ClientPostLogoutRedirectUris.Find(clientPostLogoutRedirectUriId);
            return _entity.ToModel();
        }

        public IEnumerable<ClientPostLogoutRedirectUri> GetPostLogoutRedirectUrisByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientPostLogoutRedirectUris.Where
                   (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel(); throw new NotImplementedException();
        }

        public void Insert(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri)
        {
            var _entity = clientPostLogoutRedirectUri.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientPostLogoutRedirectUris.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(ClientPostLogoutRedirectUri clientPostLogoutRedirectUri)
        {
            var _entity = clientPostLogoutRedirectUri.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
    }
}
