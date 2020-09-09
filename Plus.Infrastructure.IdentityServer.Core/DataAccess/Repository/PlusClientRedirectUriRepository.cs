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
    public class PlusClientRedirectUriRepository : IPlusClientRedirectUriRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientRedirectUriRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public async Task Delete(int clientRedirectUriId)
        {
            var _entity = _plusDataContext.ClientRedirectUris.Find(clientRedirectUriId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientRedirectUris.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task DeleteAll(int clientId)
        {
            var _redirectUri = GetRedirectUriByClientId(clientId).Result;
            _redirectUri.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientRedirectUris.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public async Task<IEnumerable<ClientRedirectUri>> GetAll()
        {
            var _entityList = _plusDataContext.ClientRedirectUris.ToList();
            return _entityList.ToModel();
        }

        public async Task<ClientRedirectUri> GetById(int clientRedirectUriId)
        {
            var _entity = _plusDataContext.ClientRedirectUris.Find(clientRedirectUriId);
            return _entity.ToModel();
        }

        public async Task<IEnumerable<ClientRedirectUri>> GetRedirectUriByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientRedirectUris.Where
               (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel();
        }

        public async Task Insert(ClientRedirectUri clientRedirectUri)
        {
            var _entity = clientRedirectUri.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientRedirectUris.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(ClientRedirectUri clientRedirectUri)
        {
            var _entity = clientRedirectUri.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
    }
}
