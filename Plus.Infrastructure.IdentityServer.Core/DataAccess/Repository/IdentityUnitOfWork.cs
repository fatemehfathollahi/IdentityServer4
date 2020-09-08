using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plus.Infrastructure.IdentityServer.Core.DataAccess.Repository
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private readonly PlusConfigurationDbContext _context;

        #region Client
        public IPlusClientRepository PlusClientRepository { get; private set; }
        public IPlusClientClaimRepository PlusClientClaimRepository { get; private set; }
        public IPlusClientGrantTypeRepository PlusClientGrantTypeRepository { get; private set; }
        public IPlusClientIdPRestrictionRepository PlusClientIdPRestrictionRepository { get; private set; }
        public IPlusClientPostLogoutRedirectUriRepository PlusClientPostLogoutRedirectUriRepository { get; private set; }
        public IPlusClientPropertyRepository PlusClientPropertyRepository { get; private set; }
        public IPlusClientRedirectUriRepository PlusClientRedirectUriRepository { get; private set; }
        public IPlusClientScopeRepository PlusClientScopeRepository { get; private set; }
        public IPlusClientSecretRepository PlusClientSecretRepository { get; private set; }
        public IPlusClientCorsOriginRepository PlusClientCorsOriginRepository { get; private set; }
        #endregion

        #region ApiResource
        public IPlusApiResourceRepository PlusApiResourceRepository { get; set; }
        public IPlusApiResourceScopeRepository PlusApiResourceScopeRepository { get; set; }
        public IPlusApiResourceSecretRepository PlusApiResourceSecretRepository { get; set; }
        public IPlusApiResourcePropertyRepository PlusApiResourcePropertyRepository { get; set; }
        public IPlusApiResourceClaimRepository PlusApiResourceClaimRepository { get; set; }
        #endregion

        public IdentityUnitOfWork(PlusConfigurationDbContext context)
        {
            _context = context;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            
            PlusClientRepository = new PlusClientRepository(_context);
            PlusClientClaimRepository = new PlusClientClaimRepository(_context);
            PlusClientGrantTypeRepository = new PlusClientGrantTypeRepository(_context);
            PlusClientIdPRestrictionRepository = new PlusClientIdPRestrictionRepository(_context);
            PlusClientPostLogoutRedirectUriRepository = new PlusClientPostLogoutRedirectUriRepository(_context);
            PlusClientPropertyRepository = new PlusClientPropertyRepository(_context);
            PlusClientRedirectUriRepository = new PlusClientRedirectUriRepository(_context);
            PlusClientScopeRepository = new PlusClientScopeRepository(_context);
            PlusClientSecretRepository = new PlusClientSecretRepository(_context);
            PlusClientCorsOriginRepository = new PlusClientCorsOriginRepository(_context);
            PlusApiResourceRepository = new PlusApiResourceRepository(_context);
            PlusApiResourceClaimRepository = new PlusApiResourceClaimRepository(_context);
            PlusApiResourcePropertyRepository = new PlusApiResourcePropertyRepository(_context);
            PlusApiResourceScopeRepository = new PlusApiResourceScopeRepository(_context);
            PlusApiResourceSecretRepository = new PlusApiResourceSecretRepository(_context);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
