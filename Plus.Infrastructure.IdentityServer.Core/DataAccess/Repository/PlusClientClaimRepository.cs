using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class PlusClientClaimRepository : IPlusClientClaimRepository
    {
        private readonly PlusConfigurationDbContext _plusDataContext;
        public PlusClientClaimRepository(PlusConfigurationDbContext plusDataContext)
        {
            this._plusDataContext = plusDataContext;
        }

        public void Delete(int claimId)
        {
            var _entity = _plusDataContext.ClientClaims.Find(claimId);
            _plusDataContext.Entry(_entity).State = EntityState.Deleted;
            _plusDataContext.ClientClaims.Remove(_entity);
            _plusDataContext.SaveChanges();
        }

        public void DeleteAll(int clientId)
        {
            var _claims = GetClaimsByClientId(clientId);
            _claims.ToList().ForEach(s =>
            {
                _plusDataContext.Entry(s.ToEntity()).State = EntityState.Deleted;
                _plusDataContext.ClientClaims.Remove(s.ToEntity());
            });
            _plusDataContext.SaveChanges();
        }

        public IEnumerable<ClientClaim> GetAll()
        {
            var _entityList = _plusDataContext.ClientClaims.ToList();
            return _entityList.ToModel();
        }

        public ClientClaim GetById(int claimId)
        {
            var _entity = _plusDataContext.ClientClaims.Find(claimId);
            return _entity.ToModel();
        }

        public IEnumerable<ClientClaim> GetClaimsByClientId(int clientId)
        {
            var _entityList = _plusDataContext.ClientClaims.Where
                (s => s.ClientId.Equals(clientId)).ToList();
            return _entityList.ToModel();
        }

        public void Insert(ClientClaim clientClaim)
        {
            var _entity = clientClaim.ToEntity();
            _plusDataContext.Entry(_entity).State = EntityState.Added;
            _plusDataContext.ClientClaims.Add(_entity);
            _plusDataContext.SaveChanges();
        }

        public void Update(ClientClaim clientClaim)
        {
            var _entity = clientClaim.ToEntity();

            if (_plusDataContext.Entry(_entity).State != EntityState.Detached)
            {
                _plusDataContext.Entry(_entity).State = EntityState.Detached;
            }
            _plusDataContext.Entry(_entity).State = EntityState.Modified;
            _plusDataContext.SaveChanges();
        }
    }
}
