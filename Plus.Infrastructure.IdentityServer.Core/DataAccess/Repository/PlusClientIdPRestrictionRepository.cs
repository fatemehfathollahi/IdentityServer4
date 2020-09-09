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
    public class PlusClientIdPRestrictionRepository : IPlusClientIdPRestrictionRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientIdPRestrictionRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }


        public async Task Delete(int clientIdPRestrictionId)
        {
            var _entity = _plusDataContext.ClientIdPRestrictions.Find(clientIdPRestrictionId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientIdPRestrictions.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task DeleteAll(int clientId)
        {
            var _restrictions = GetClientIdPRestrictionsByClientId(clientId).Result;
            _restrictions.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientIdPRestrictions.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public async Task<IEnumerable<ClientIdPRestriction>> GetAll()
        {
            var _entityList = _plusDataContext.ClientIdPRestrictions.ToList();
            return _entityList.ToModel();
        }

        public async Task<ClientIdPRestriction> GetById(int clientIdPRestrictionId)
        {
            var _entity = _plusDataContext.ClientIdPRestrictions.Find(clientIdPRestrictionId);
            return _entity.ToModel();
        }

        public async Task<IEnumerable<ClientIdPRestriction>> GetClientIdPRestrictionsByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientIdPRestrictions.Where
                (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel();
        }

        public async Task Insert(ClientIdPRestriction clientIdPRestriction)
        {
            var _entity = clientIdPRestriction.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientIdPRestrictions.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(ClientIdPRestriction clientIdPRestriction)
        {
            var _entity = clientIdPRestriction.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
    }
}
