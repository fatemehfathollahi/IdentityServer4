using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Core.Mapping;

namespace Plus.Infrastructure.IdentityServer.Core.Stors
{
    public class PlusClientStore : IClientStore
    {
        private readonly IPlusClientService clientService;
       // private readonly IIdentityConfigurationDbContext _context;
        private readonly ILogger<PlusClientStore> _logger;

        public PlusClientStore(IPlusClientService clientService, ILogger<PlusClientStore> logger)
        {
            this.clientService = clientService;
            _logger = logger;
        }
        //public PlusClientStore(IIdentityConfigurationDbContext context, ILogger<PlusClientStore> logger)
        //{
        //    _context = context ?? throw new ArgumentNullException(nameof(context));
        //    _logger = logger;
        //}

        //public Task<IdentityServer4.Models.Client> CreateAsync(Domain.Models.Client client)
        //{
        //    _context.Clients.Add(client);
        //    _context.SaveChangesAsync();
        //    var model =   client.ToModel();
        //    return Task.FromResult(model);
        //}

        public Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        {
            var _client = clientService.GetByClientId(clientId);
            var model = _client?.ToModel();
            _logger.LogDebug("{clientId} found in database: {clientIdFound}", clientId, model != null);

            return Task.FromResult(model);
        }

        //public Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        //{
        //    var client = _context.Clients
        //        .Include(x => x.AllowedGrantTypes)
        //        .Include(x => x.RedirectUris)
        //        .Include(x => x.PostLogoutRedirectUris)
        //        .Include(x => x.AllowedScopes)
        //        .Include(x => x.ClientSecrets)
        //        .Include(x => x.Claims)
        //        .Include(x => x.IdentityProviderRestrictions)
        //        .Include(x => x.AllowedCorsOrigins)
        //        .Include(x => x.Properties)
        //        .AsNoTracking()
        //        .FirstOrDefault(x => x.ClientId == clientId);
        //    var model = client?.ToModel();

        //    _logger.LogDebug("{clientId} found in database: {clientIdFound}", clientId, model != null);

        //    return Task.FromResult(model);
        //}

    }
   
}
