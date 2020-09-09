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
    public class PlusApiResourcePropertyRepository : IPlusApiResourcePropertyRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusApiResourcePropertyRepository(PlusConfigurationDbContext plusDataContext)
        {
            _plusDataContext = plusDataContext;
        }

        public async Task<ApiResourceProperty> GetById(int propertyId)
        {
            var _entity = _plusDataContext.ApiResourceProperties.Find(propertyId);
            return _entity.ToModel();
        }

        public async Task<IEnumerable<ApiResourceProperty>> GetPropertiesByResourceId(int resourceId)
        {
            var _entityList = _plusDataContext.ApiResourceProperties.Where
               (s => s.ApiResourceId.Equals(resourceId)).ToList();
            return _entityList.ToModel();
        }

        public async Task Insert(ApiResourceProperty apiProperty)
        {
            var _entity = apiProperty.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ApiResourceProperties.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task Update(ApiResourceProperty apiProperty)
        {
            var _entity = apiProperty.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }

        public async Task DeleteAll(int resourceId)
        {
            var _scopes = GetPropertiesByResourceId(resourceId).Result;
            _scopes.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ApiResourceProperties.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public async Task Delete(int propertyId)
        {
            var _entity = _plusDataContext.ApiResourceProperties.Find(propertyId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ApiResourceProperties.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public async Task<IEnumerable<ApiResourceProperty>> GetAll()
        {
            var _entityList = _plusDataContext.ApiResourceProperties.ToList();
            return _entityList.ToModel();
        }
    }
}
