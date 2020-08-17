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
        private readonly IConfigurationDbContext _context;
        private readonly ILogger<PlusClientStore> _logger;


        public PlusClientStore(IConfigurationDbContext context, ILogger<PlusClientStore> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public Task<Client> CreateAsync(PlusClient client)
        {
            _context.PlusClients.Add(client);
            _context.SaveChangesAsync();
            var model =   client.ToModel();
            return Task.FromResult(model);
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = _context.PlusClients
                .Include(x => x.AllowedGrantTypes)
                .Include(x => x.RedirectUris)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.AllowedScopes)
                .Include(x => x.ClientSecrets)
                .Include(x => x.Claims)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.AllowedCorsOrigins)
                .Include(x => x.Properties)
                .AsNoTracking()
                .FirstOrDefault(x => x.ClientId == clientId);
            var model = client?.ToModel();

            _logger.LogDebug("{clientId} found in database: {clientIdFound}", clientId, model != null);

            return Task.FromResult(model);
        }

    }
   
}
