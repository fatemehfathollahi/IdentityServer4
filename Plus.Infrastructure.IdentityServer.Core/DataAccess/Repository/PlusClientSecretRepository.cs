using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusClientSecretRepository : IPlusClientSecretRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientSecretRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public void Delete(int clientId)
        {
            var _entity = _plusDataContext.ClientSecret.Find(clientId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientSecret.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public void DeleteAll(int clientId)
        {
            var _secrets = GetSecretsByClientId(clientId);
            _secrets.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientSecret.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public IEnumerable<ClientSecret> GetAll()
        {
            var _entityList = _plusDataContext.ClientSecret.ToList();
            return _entityList.ToModel();
        }

        public ClientSecret GetById(int secretId)
        {
            var _entity = _plusDataContext.ClientSecret.Find(secretId);
            return _entity.ToModel();
        }

        public IEnumerable<ClientSecret> GetSecretsByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientSecret.Where
                (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel();
        }

        public void Insert(ClientSecret clientSecret)
        {
            var _entity = clientSecret.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientSecret.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(ClientSecret clientSecret)
        {
            var _entity = clientSecret.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
    }
}
