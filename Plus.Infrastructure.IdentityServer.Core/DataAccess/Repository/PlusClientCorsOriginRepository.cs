using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusClientCorsOriginRepository : IPlusClientCorsOriginRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientCorsOriginRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }
        public async Task Delete(int corsOriginId)
        {
            var _entity = _plusDataContext.ClientCorsOrigins.Find(corsOriginId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientCorsOrigins.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task DeleteAll(int clientId)
        {
            var _corseOrigins = GetCorsOriginByClientId(clientId).Result;
            _corseOrigins.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientCorsOrigins.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public async Task<IEnumerable<ClientCorsOrigin>> GetAll()
        {
            var _entityList = _plusDataContext.ClientCorsOrigins.ToList();
            return _entityList.ToModel();
        }

        public async Task<ClientCorsOrigin> GetById(int corsOriginId)
        {
            var _entity = _plusDataContext.ClientCorsOrigins.Find(corsOriginId);
            return _entity.ToModel();
        }

        public async Task<IEnumerable<ClientCorsOrigin>> GetCorsOriginByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientCorsOrigins.Where
               (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel();
        }

        public async Task Insert(ClientCorsOrigin clientCorsOrigin)
        {
            var _entity = clientCorsOrigin.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientCorsOrigins.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(ClientCorsOrigin clientCorsOrigin)
        {
            var _entity = clientCorsOrigin.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
    }
}
