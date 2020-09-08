﻿using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusClientGrantTypeRepository : IPlusClientGrantTypeRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientGrantTypeRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public void Delete(int grantTypeId)
        {
            var _entity = _plusDataContext.ClientGrantTypes.Find(grantTypeId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientGrantTypes.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public void DeleteAll(int clientId)
        {
            var _grantTypes = GetGrantTypesByClientId(clientId);
            _grantTypes.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientGrantTypes.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public IEnumerable<ClientGrantType> GetAll()
        {
            var _entityList = _plusDataContext.ClientGrantTypes.ToList();
            return _entityList.ToModel();
        }

        public ClientGrantType GetById(int grantTypeId)
        {
            var _entity = _plusDataContext.ClientGrantTypes.Find(grantTypeId);
            return _entity.ToModel();
        }

        public IEnumerable<ClientGrantType> GetGrantTypesByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientGrantTypes.Where
               (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel();
        }

        public void Insert(ClientGrantType clientGrantType)
        {
            var _entity = clientGrantType.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientGrantTypes.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(ClientGrantType clientGrantType)
        {
            var _entity = clientGrantType.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
    }
}
