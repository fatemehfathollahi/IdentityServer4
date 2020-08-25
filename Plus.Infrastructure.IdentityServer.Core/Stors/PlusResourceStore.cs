using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Plus.Infrastructure.IdentityServer.Core.Mapping;
using Plus.Infrastructure.IdentityServer.Core.DataAccess.DataContext;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using IdentityServer4.Stores;

namespace Plus.Infrastructure.IdentityServer.Core.Stors
{
    public class PlusResourceStore// : IResourceStore
    {
        private readonly IIdentityConfigurationDbContext _context;
        private readonly ILogger<PlusResourceStore> _logger;

        public PlusResourceStore(IIdentityConfigurationDbContext context, ILogger<PlusResourceStore> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

     
        //public Task<ApiResource> FindApiResourceAsync(string name)
        //{
        //    var query =
        //        from apiResource in _context.ApiResources
        //        where apiResource.Name == name
        //        select apiResource;

        //    var apis = query
        //        .Include(x => x.Secrets)
        //        .Include(x => x.Scopes)
        //            .ThenInclude(s => s.UserClaims)
        //        .Include(x => x.UserClaims)
        //        .Include(x => x.Properties)
        //        .AsNoTracking();

        //    var api = apis.FirstOrDefault();

        //    if (api != null)
        //    {
        //        _logger.LogDebug("Found {api} API resource in database", name);
        //    }
        //    else
        //    {
        //        _logger.LogDebug("Did not find {api} API resource in database", name);
        //    }

        //    return Task.FromResult(api.ToModel());
        //}

        //public Task<IEnumerable<ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        //{
        //    var names = scopeNames.ToArray();

        //    var query =
        //        from api in _context.ApiResources
        //        where api.Scopes.Where(x=>names.Contains(x.Name)).Any()
        //        select api;

        //    var apis = query
        //        .Include(x => x.Secrets)
        //        .Include(x => x.Scopes)
        //            .ThenInclude(s => s.UserClaims)
        //        .Include(x => x.UserClaims)
        //        .Include(x => x.Properties)
        //        .AsNoTracking();

        //    var results = apis.ToArray();
        //    var models = results.Select(x => x.ToModel()).ToArray();

        //    _logger.LogDebug("Found {scopes} API scopes in database", models.SelectMany(x => x.Scopes).Select(x => x.Length)); 

        //    return Task.FromResult(models.AsEnumerable());
        //}

        //public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        //{
        //    var scopes = scopeNames.ToArray();

        //    var query =
        //        from identityResource in _context.IdentityResources
        //        where scopes.Contains(identityResource.Name)
        //        select identityResource;

        //    var resources = query
        //        .Include(x => x.UserClaims)
        //        .Include(x => x.Properties)
        //        .AsNoTracking();

        //    var results = resources.ToArray();

        //    _logger.LogDebug("Found {scopes} identity scopes in database", results.Select(x => x.Name));

        //    return Task.FromResult(results.Select(x => x.ToModel()).ToArray().AsEnumerable());
        //}

        //public Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Resources> GetAllResourcesAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Resources> GetAllResourcesAsync()
        //{
        //    var identity = _context.IdentityResources
        //      .Include(x => x.UserClaims);

        //    var apiScope = _context.ApiScops
        //      .Include(x => x.UserClaims);

        //    var apis = _context.ApiResources
        //        .Include(x => x.Secrets)
        //        .Include(x => x.Scopes)
        //            .ThenInclude(s => s.UserClaims)
        //        .Include(x => x.UserClaims)
        //        .Include(x => x.Properties)
        //        .AsNoTracking();



        //    var result = new Resources(
        //        identity.ToArray().Select(x => x.ToModel()).AsEnumerable(),
        //        apiScope.ToArray().Select(x => x.ToModel()).AsEnumerable(),
        //        apis.ToArray().Select(x => x.ToModel()).AsEnumerable());

        //    _logger.LogDebug("Found {scopes} as all scopes in database", result.IdentityResources.Select(x => x.Name).Union(result.ApiResources.SelectMany(x => x.Scopes).Select(x => x.Name)));

        //    return Task.FromResult(result);
        //}
    }
}