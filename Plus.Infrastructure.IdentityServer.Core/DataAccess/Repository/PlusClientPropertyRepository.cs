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
    public class PlusClientPropertyRepository : IPlusClientPropertyRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientPropertyRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public async Task Delete(int propertyId)
        {
            var _entity = _plusDataContext.ClientProperties.Find(propertyId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientProperties.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task DeleteAll(int clientId)
        {
            var _properties = GetPropertiesByClientId(clientId).Result;
            _properties.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientProperties.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public async Task<IEnumerable<ClientProperty>> GetAll()
        {
            var _entityList = _plusDataContext.ClientProperties.ToList();
            return _entityList.ToModel();
        }

        public async Task<ClientProperty> GetById(int propertyId)
        {
            var _entity = _plusDataContext.ClientProperties.Find(propertyId);
            return _entity.ToModel();
        }

        public async Task<IEnumerable<ClientProperty>> GetPropertiesByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientProperties.Where
               (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel();
        }

        public async Task Insert(ClientProperty clientProperty)
        {
            var _entity = clientProperty.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientProperties.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(ClientProperty clientProperty)
        {
            var _entity = clientProperty.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
    }
}
