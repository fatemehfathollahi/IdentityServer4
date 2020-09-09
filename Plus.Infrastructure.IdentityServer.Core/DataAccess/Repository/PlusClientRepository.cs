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
    public class PlusClientRepository : IPlusClientRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var _entityList = _plusDataContext.Clients.Include(r => r.ClientSecrets)
                .Include(r => r.PostLogoutRedirectUris).Include(r => r.RedirectUris)
                .Include(r => r.AllowedCorsOrigins).Include(r => r.AllowedGrantTypes)
                .Include(r => r.IdentityProviderRestrictions).Include(r => r.Claims)
                 .Include(r => r.AllowedScopes).Include(r => r.Properties).ToList();
            return _entityList.ToModel();
        }

        public async Task<Client> GetById(int id)
        {
            var _entity = GetAll().Result.Where(r => r.Id.Equals(id)).FirstOrDefault();
            return _entity;
        }

        public async Task<int> Insert(Client client)
        {
            var _entity = client.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.Clients.Add(_entity);
            _plusDataContext.SaveChanges();
            return _entity.Id;
        }

        public async Task<int> Update(Client client)
        {
            var _entity = client.ToEntity();
            // plusDataContext.Entry(_entity).State = EntityState.Detached;
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.Clients.Update(_entity);
            _plusDataContext.SaveChanges();
            return _entity.Id;
        }

        public async Task Delete(int id)
        {
            var _entity = _plusDataContext.Clients.Find(id);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.Clients.Remove(_entity);
            _plusDataContext.SaveChanges();
        }
    }
}
