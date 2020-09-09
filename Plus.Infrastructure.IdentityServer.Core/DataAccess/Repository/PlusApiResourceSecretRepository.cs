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
    public class PlusApiResourceSecretRepository : IPlusApiResourceSecretRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourceSecretRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public async Task<ApiResourceSecret> GetById(int secretId)
        {
            var _entity = _plusDataContext.ApiResourceSecrets.Find(secretId);
            return _entity.ToModel();
        }

        public async Task<IEnumerable<ApiResourceSecret>> GetSecretsByResourceId(int resourceId)
        {
            var _entityList = _plusDataContext.ApiResourceSecrets.Where
                (s => s.ApiResourceId.Equals(resourceId)).ToList();
            return _entityList.ToModel();
        }

        public async Task Insert(ApiResourceSecret apiSecret)
        {
            var _entity = apiSecret.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResourceSecrets.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(ApiResourceSecret apiSecret)
        {
            var _entity = apiSecret.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }

        public async Task DeleteAll(int resourceId)
        {
            var _scopes = GetSecretsByResourceId(resourceId).Result;
            _scopes.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ApiResourceSecrets.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }
      
        public async Task Delete(int secretId)
        {
            var _entity = _plusDataContext.ApiResourceSecrets.Find(secretId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ApiResourceSecrets.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task<IEnumerable<ApiResourceSecret>> GetAll()
        {
            var _entityList = _plusDataContext.ApiResourceSecrets.ToList();
            return _entityList.ToModel();
        }
    }
}
