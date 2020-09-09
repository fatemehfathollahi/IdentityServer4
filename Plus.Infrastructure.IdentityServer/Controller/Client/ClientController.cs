using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Models;
using Plus.Infrastructure.IdentityServer.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Controllers
{
    /// <summary>آ
    /// This controller processes the client UI
    /// </summary>
    //[SecurityHeaders]
    [AllowAnonymous]
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IPlusClientService _clientService;

        public ClientController(IPlusClientService clientService,
            ILogger<ClientController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _allClient = await _clientService.GetAll();
            var _vm = new List<ClientViewModel>();

            _allClient.ToList().ForEach(model => _vm.Add(new ClientViewModel
            {
                Id = model.Id,
                AccessTokenLifetime = model.AccessTokenLifetime,
                AuthorizationCodeLifetime = model.AuthorizationCodeLifetime,
                ConsentLifetime = model.ConsentLifetime,
                AbsoluteRefreshTokenLifetime = model.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = model.SlidingRefreshTokenLifetime,
                RefreshTokenUsage = model.RefreshTokenUsage,
                UpdateAccessTokenClaimsOnRefresh = model.UpdateAccessTokenClaimsOnRefresh,
                RefreshTokenExpiration = model.RefreshTokenExpiration,
                AccessTokenType = model.AccessTokenType,
                EnableLocalLogin = model.EnableLocalLogin,
                IncludeJwtId = model.IncludeJwtId,
                AlwaysSendClientClaims = model.AlwaysSendClientClaims,
                ClientClaimsPrefix = model.ClientClaimsPrefix,
                PairWiseSubjectSalt = model.PairWiseSubjectSalt,
                Created = model.Created,
                Updated = model.Updated,
                LastAccessed = model.LastAccessed,
                UserSsoLifetime = model.UserSsoLifetime,
                UserCodeType = model.UserCodeType,
                AllowedIdentityTokenSigningAlgorithms = model.AllowedIdentityTokenSigningAlgorithms,
                IdentityTokenLifetime = model.IdentityTokenLifetime,
                AllowOfflineAccess = model.AllowOfflineAccess,
                Enabled = model.Enabled,
                ClientId = model.ClientId,
                ProtocolType = model.ProtocolType,
                RequireClientSecret = model.RequireClientSecret,
                ClientName = model.ClientName,
                Description = model.Description,
                ClientUri = model.ClientUri,
                LogoUri = model.LogoUri,
                RequireConsent = model.RequireConsent,
                DeviceCodeLifetime = model.DeviceCodeLifetime,
                AllowRememberConsent = model.AllowRememberConsent,
                RequirePkce = model.RequirePkce,
                AllowPlainTextPkce = model.AllowPlainTextPkce,
                RequireRequestObject = model.RequireRequestObject,
                AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser,
                FrontChannelLogoutUri = model.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = model.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = model.BackChannelLogoutUri,
                BackChannelLogoutSessionRequired = model.BackChannelLogoutSessionRequired,
                AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken,
                NonEditable = model.NonEditable

            }));


            _vm.ForEach(v => v.Scopes = _clientService.GetScopesByClientId(v.Id).Result
            .ToList().Select(s => new ScopeItem
            {
                Id = s.Id,
                Scope = s.Scope
            }));

            _vm.ForEach(v => v.Secrets = _clientService.GetSecretsByClientId(v.Id).Result
           .ToList().Select(s => new SecretItem
           {
               Id = s.Id,
               Value = s.Value,
               Type = s.Type,
               Description = s.Description,
               Expiration = s.Expiration,
               Created = s.Created
           }));

            _vm.ForEach(v => v.Claims = _clientService.GetClaimsByClientId(v.Id).Result
          .ToList().Select(s => new ClientClaimItem
          {
              Id = s.Id,
              Type = s.Type,
              Value = s.Value
          }));

            _vm.ForEach(v => v.Properties = _clientService.GetPropertiesByClientId(v.Id).Result
       .ToList().Select(s => new PropertyItem
       {
           Id = s.Id,
           Key = s.Key,
           Value = s.Value
       }));


            _vm.ForEach(v => v.CorsOrigins = _clientService.GetCorsOriginsByClientId(v.Id).Result
            .ToList().Select(s => new CorsOriginItem
            {
                Id = s.Id,
                Origin = s.Origin
            }));

            _vm.ForEach(v => v.PostLogoutRedirectUris = _clientService.GetPostLogoutRedirectUrisByClientId(v.Id).Result
           .ToList().Select(s => new PostLogoutRedirectUriItem
           {
               Id = s.Id,
               PostLogoutRedirectUri = s.PostLogoutRedirectUri
           }));

            _vm.ForEach(v => v.RedirectUris = _clientService.GetRedirectUriByClientId(v.Id).Result
          .ToList().Select(s => new RedirectUriItem
          {
              Id = s.Id,
              RedirectUri = s.RedirectUri
          }));

            _vm.ForEach(v => v.IdentityProviderRestrictions = _clientService.GetClientIdPRestrictionsByClientId(v.Id).Result
       .ToList().Select(s => new IdPRestrictionItem
       {
           Id = s.Id,
           Provider = s.Provider
       }));

            _vm.ForEach(v => v.GrantTypes = _clientService.GetGrantTypesByClientId(v.Id).Result
       .ToList().Select(s => new GrantTypeItem
       {
           Id = s.Id,
           GrantType = s.GrantType
       }));
        

            return View("Index", _vm);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var model = new AddEditClientViewModel
            {
                AccessTokenLifetime = 0,
                AuthorizationCodeLifetime = 0,
                AbsoluteRefreshTokenLifetime = 0,
                SlidingRefreshTokenLifetime=0,
                RefreshTokenUsage = 0,
                RefreshTokenExpiration = 0,
                AccessTokenType = 0,
                IdentityTokenLifetime = 0,
                Created = DateTime.Now,
                DeviceCodeLifetime = 0,
            };
            return View("Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddEditClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = new Client
            {
                AccessTokenLifetime = model.AccessTokenLifetime,
                AuthorizationCodeLifetime = model.AuthorizationCodeLifetime,
                ConsentLifetime = model.ConsentLifetime,
                AbsoluteRefreshTokenLifetime = model.AbsoluteRefreshTokenLifetime,
                SlidingRefreshTokenLifetime = model.SlidingRefreshTokenLifetime,
                RefreshTokenUsage = model.RefreshTokenUsage,
                UpdateAccessTokenClaimsOnRefresh = model.UpdateAccessTokenClaimsOnRefresh,
                RefreshTokenExpiration = model.RefreshTokenExpiration,
                AccessTokenType = model.AccessTokenType,
                EnableLocalLogin = model.EnableLocalLogin,
                IncludeJwtId = model.IncludeJwtId,
                AlwaysSendClientClaims = model.AlwaysSendClientClaims,
                ClientClaimsPrefix = model.ClientClaimsPrefix,
                PairWiseSubjectSalt = model.PairWiseSubjectSalt,
                Created = model.Created,
                Updated = model.Updated,
                LastAccessed = model.LastAccessed,
                UserSsoLifetime = model.UserSsoLifetime,
                UserCodeType = model.UserCodeType,
                AllowedIdentityTokenSigningAlgorithms = model.AllowedIdentityTokenSigningAlgorithms,
                IdentityTokenLifetime = model.IdentityTokenLifetime,
                AllowOfflineAccess = model.AllowOfflineAccess,
                Enabled = model.Enabled,
                ClientId = model.ClientId,
                ProtocolType = model.ProtocolType,
                RequireClientSecret = model.RequireClientSecret,
                ClientName = model.ClientName,
                Description = model.Description,
                ClientUri = model.ClientUri,
                LogoUri = model.LogoUri,
                RequireConsent = model.RequireConsent,
                DeviceCodeLifetime = model.DeviceCodeLifetime,
                AllowRememberConsent = model.AllowRememberConsent,
                RequirePkce = model.RequirePkce,
                AllowPlainTextPkce = model.AllowPlainTextPkce,
                RequireRequestObject = model.RequireRequestObject,
                AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser,
                FrontChannelLogoutUri = model.FrontChannelLogoutUri,
                FrontChannelLogoutSessionRequired = model.FrontChannelLogoutSessionRequired,
                BackChannelLogoutUri = model.BackChannelLogoutUri,
                BackChannelLogoutSessionRequired = model.BackChannelLogoutSessionRequired,
                AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken,
                NonEditable = model.NonEditable

            };

            var _clientId = await _clientService.Insert(obj);


            model.Scopes.ForEach(s =>  _clientService.AddScope(
               new ClientScope
               {
                   ClientId = _clientId,
                   Scope = s.Scope
               }));

            model.Secrets.ForEach(s => _clientService.AddSecret(
              new ClientSecret
              {
                  ClientId = _clientId,
                  Description = s.Description,
                  Value = s.Value,
                  Type = s.Type,
                  Created = s.Created,
                  Expiration = s.Expiration
              }));

            model.Claims.ForEach(s => _clientService.AddClaim(
              new ClientClaim
              {
                  ClientId = _clientId,
                  Type = s.Type,
                  Value = s.Value
              }));

            model.Properties.ForEach(s => _clientService.AddProperty(
              new ClientProperty
              {
                  ClientId = _clientId,
                  Value = s.Value,
                  Key = s.Key
              }));

            model.CorsOrigins.ForEach(s => _clientService.AddCorsOrigin(
             new ClientCorsOrigin
             {
                 ClientId = _clientId,
                 Origin = s.Origin
             }));

            model.PostLogoutRedirectUris.ForEach(s => _clientService.AddPostLogoutRedirectUri(
             new ClientPostLogoutRedirectUri
             {
                 ClientId = _clientId,
                 PostLogoutRedirectUri = s.PostLogoutRedirectUri
             }));

            model.RedirectUris.ForEach(s => _clientService.AddRedirectUri(
            new ClientRedirectUri
            {
                ClientId = _clientId,
                RedirectUri = s.RedirectUri
            }));

           model.GrantTypes.ForEach(s => _clientService.AddGrantType(
           new ClientGrantType
           {
               ClientId = _clientId,
               GrantType = s.GrantType
           }));

            ViewBag.Message = "Created";
            return View("Success", model);
            // return Redirect("index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _clientService.GetById(id);
            if (model != null)
            {
                var vm = new AddEditClientViewModel
                {
                    Id = model.Id,
                    AccessTokenLifetime = model.AccessTokenLifetime,
                    AuthorizationCodeLifetime = model.AuthorizationCodeLifetime,
                    ConsentLifetime = model.ConsentLifetime,
                    AbsoluteRefreshTokenLifetime = model.AbsoluteRefreshTokenLifetime,
                    SlidingRefreshTokenLifetime = model.SlidingRefreshTokenLifetime,
                    RefreshTokenUsage = model.RefreshTokenUsage,
                    UpdateAccessTokenClaimsOnRefresh = model.UpdateAccessTokenClaimsOnRefresh,
                    RefreshTokenExpiration = model.RefreshTokenExpiration,
                    AccessTokenType = model.AccessTokenType,
                    EnableLocalLogin = model.EnableLocalLogin,
                    IncludeJwtId = model.IncludeJwtId,
                    AlwaysSendClientClaims = model.AlwaysSendClientClaims,
                    ClientClaimsPrefix = model.ClientClaimsPrefix,
                    PairWiseSubjectSalt = model.PairWiseSubjectSalt,
                    Created = model.Created,
                    Updated = model.Updated,
                    LastAccessed = model.LastAccessed,
                    UserSsoLifetime = model.UserSsoLifetime,
                    UserCodeType = model.UserCodeType,
                    AllowedIdentityTokenSigningAlgorithms = model.AllowedIdentityTokenSigningAlgorithms,
                    IdentityTokenLifetime = model.IdentityTokenLifetime,
                    AllowOfflineAccess = model.AllowOfflineAccess,
                    Enabled = model.Enabled,
                    ClientId = model.ClientId,
                    ProtocolType = model.ProtocolType,
                    RequireClientSecret = model.RequireClientSecret,
                    ClientName = model.ClientName,
                    Description = model.Description,
                    ClientUri = model.ClientUri,
                    LogoUri = model.LogoUri,
                    RequireConsent = model.RequireConsent,
                    DeviceCodeLifetime = model.DeviceCodeLifetime,
                    AllowRememberConsent = model.AllowRememberConsent,
                    RequirePkce = model.RequirePkce,
                    AllowPlainTextPkce = model.AllowPlainTextPkce,
                    RequireRequestObject = model.RequireRequestObject,
                    AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser,
                    FrontChannelLogoutUri = model.FrontChannelLogoutUri,
                    FrontChannelLogoutSessionRequired = model.FrontChannelLogoutSessionRequired,
                    BackChannelLogoutUri = model.BackChannelLogoutUri,
                    BackChannelLogoutSessionRequired = model.BackChannelLogoutSessionRequired,
                    AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken,
                    NonEditable = model.NonEditable

                };

                model.AllowedScopes.ForEach(s => vm.Scopes.Add(new ScopeItem
                {
                    Id = s.Id,
                    Scope = s.Scope
                }));

                model.ClientSecrets.ForEach(s => vm.Secrets.Add(new SecretItem
                {
                    Id = s.Id,
                    Value = s.Value,
                    Description = s.Description,
                    Type = s.Type,
                    Created = s.Created,
                    Expiration = s.Expiration
                }));

                model.Claims.ForEach(s => vm.Claims.Add(new ClientClaimItem
                {
                    Id = s.Id,
                    Type = s.Type,
                    Value = s.Value
                }));

                model.Properties.ForEach(s => vm.Properties.Add(new PropertyItem
                {
                    Id = s.Id,
                    Key = s.Key,
                    Value = s.Value
                }));


                model.AllowedCorsOrigins.ForEach(s => vm.CorsOrigins.Add(new CorsOriginItem
                {
                    Id = s.Id,
                    Origin = s.Origin
                }));

                model.PostLogoutRedirectUris.ForEach(s => vm.PostLogoutRedirectUris.Add(new PostLogoutRedirectUriItem
                {
                    Id = s.Id,
                    PostLogoutRedirectUri = s.PostLogoutRedirectUri
                }));

                model.RedirectUris.ForEach(s => vm.RedirectUris.Add(new RedirectUriItem
                {
                    Id = s.Id,
                    RedirectUri = s.RedirectUri
                }));

                model.IdentityProviderRestrictions.ForEach(s => vm.Restrictions.Add(new IdPRestrictionItem
                {
                    Id = s.Id,
                    Provider = s.Provider
                }));

                model.AllowedGrantTypes.ForEach(s => vm.GrantTypes.Add(new GrantTypeItem
                {
                    Id = s.Id,
                    GrantType = s.GrantType
                }));

                return View("Edit", vm);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddEditClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client = await _clientService.GetById(model.Id);

            client.AccessTokenLifetime = model.AccessTokenLifetime;
            client.AuthorizationCodeLifetime = model.AuthorizationCodeLifetime;
            client.ConsentLifetime = model.ConsentLifetime;
            client.AbsoluteRefreshTokenLifetime = model.AbsoluteRefreshTokenLifetime;
            client.SlidingRefreshTokenLifetime = model.SlidingRefreshTokenLifetime;
            client.RefreshTokenUsage = model.RefreshTokenUsage;
            client.UpdateAccessTokenClaimsOnRefresh = model.UpdateAccessTokenClaimsOnRefresh;
            client.RefreshTokenExpiration = model.RefreshTokenExpiration;
            client.AccessTokenType = model.AccessTokenType;
            client.EnableLocalLogin = model.EnableLocalLogin;
            client.IncludeJwtId = model.IncludeJwtId;
            client.AlwaysSendClientClaims = model.AlwaysSendClientClaims;
            client.ClientClaimsPrefix = model.ClientClaimsPrefix;
            client.PairWiseSubjectSalt = model.PairWiseSubjectSalt;
            client.Created = model.Created;
            client.Updated = model.Updated;
            client.LastAccessed = model.LastAccessed;
            client.UserSsoLifetime = model.UserSsoLifetime;
            client.UserCodeType = model.UserCodeType;
            client.AllowedIdentityTokenSigningAlgorithms = model.AllowedIdentityTokenSigningAlgorithms;
            client.IdentityTokenLifetime = model.IdentityTokenLifetime;
            client.AllowOfflineAccess = model.AllowOfflineAccess;
            client.Enabled = model.Enabled;
            client.ClientId = model.ClientId;
            client.ProtocolType = model.ProtocolType;
            client.RequireClientSecret = model.RequireClientSecret;
            client.ClientName = model.ClientName;
            client.Description = model.Description;
            client.ClientUri = model.ClientUri;
            client.LogoUri = model.LogoUri;
            client.RequireConsent = model.RequireConsent;
            client.DeviceCodeLifetime = model.DeviceCodeLifetime;
            client.AllowRememberConsent = model.AllowRememberConsent;
            client.RequirePkce = model.RequirePkce;
            client.AllowPlainTextPkce = model.AllowPlainTextPkce;
            client.RequireRequestObject = model.RequireRequestObject;
            client.AllowAccessTokensViaBrowser = model.AllowAccessTokensViaBrowser;
            client.FrontChannelLogoutUri = model.FrontChannelLogoutUri;
            client.FrontChannelLogoutSessionRequired = model.FrontChannelLogoutSessionRequired;
            client.BackChannelLogoutUri = model.BackChannelLogoutUri;
            client.BackChannelLogoutSessionRequired = model.BackChannelLogoutSessionRequired;
            client.AlwaysIncludeUserClaimsInIdToken = model.AlwaysIncludeUserClaimsInIdToken;
            client.NonEditable = model.NonEditable;

            var _clientId = await _clientService.Update(client);



            foreach (var scope in model.Scopes)
            {
                var _scope = client.AllowedScopes.Where(s => s.Id.Equals(scope.Id)).FirstOrDefault();
                _scope.Scope = scope.Scope;
               await _clientService.UpdateScope(_scope);
            }

            foreach (var secret in model.Secrets)
            {
                var _secret = client.ClientSecrets.Where(s => s.Id.Equals(secret.Id)).FirstOrDefault();
                _secret.Value = secret.Value;
                _secret.Description = secret.Description;
                _secret.Type = secret.Type;
                _secret.Created = secret.Created;
                _secret.Expiration = secret.Expiration;
               await _clientService.UpdateSecret(_secret);
            }

            foreach (var claim in model.Claims)
            {
                var _claim = client.Claims.Where(s => s.Id.Equals(claim.Id)).FirstOrDefault();
                _claim.Type = claim.Type;
                _claim.Value = claim.Value;
               await _clientService.UpdateClaim(_claim);
            }

            foreach (var property in model.Properties)
            {
                var _property = client.Properties.Where(s => s.Id.Equals(property.Id)).FirstOrDefault();
                _property.Key = property.Key;
                _property.Value = property.Value;
               await _clientService.UpdateProperty(_property);
            }

            foreach (var corsOrigin in model.CorsOrigins)
            {
                var _corsOrigin = client.AllowedCorsOrigins.Where(s => s.Id.Equals(corsOrigin.Id)).FirstOrDefault();
                _corsOrigin.Origin = corsOrigin.Origin;
               await _clientService.UpdateCorsOrigin(_corsOrigin);
            }

            foreach (var grantType in model.GrantTypes)
            {
                var _grantType = client.AllowedGrantTypes.Where(s => s.Id.Equals(grantType.Id)).FirstOrDefault();
                _grantType.GrantType = grantType.GrantType;
               await _clientService.UpdateGrantType(_grantType);
            }

            foreach (var postLogoutRedirect in model.PostLogoutRedirectUris)
            {
                var _postLogoutRedirect = client.PostLogoutRedirectUris.Where(s => s.Id.Equals(postLogoutRedirect.Id)).FirstOrDefault();
                _postLogoutRedirect.PostLogoutRedirectUri = postLogoutRedirect.PostLogoutRedirectUri;
               await  _clientService.UpdatePostLogoutRedirectUri(_postLogoutRedirect);
            }

            foreach (var redirectUri in model.RedirectUris)
            {
                var _redirectUri = client.RedirectUris.Where(s => s.Id.Equals(redirectUri.Id)).FirstOrDefault();
                _redirectUri.RedirectUri = redirectUri.RedirectUri;
               await _clientService.UpdateRedirectUri(_redirectUri);
            }

            foreach (var restriction in model.Restrictions)
            {
                var _restriction = client.IdentityProviderRestrictions.Where(s => s.Id.Equals(restriction.Id)).FirstOrDefault();
                _restriction.Provider = restriction.Provider;
               await _clientService.UpdateRestriction(_restriction);
            }
            ViewBag.Message = "Edited";
            return View("Success", model);
            // return Redirect("index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var _entity =await _clientService.GetById(id);
            if (_entity != null)
            {
                var _model = new DeleteClientViewModel
                {
                    Id = _entity.Id,
                    Name = _entity.ClientName
                };
                return View("Delete", _model);
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<ActionResult> Delete(DeleteClientViewModel model)
        {
           await _clientService.Delete(model.Id);
            return Redirect("Index");
        }

      
        #region EditorFor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddScope([Bind("Scopes")] AddEditClientViewModel model)
        {
            model.Scopes.Add(new ScopeItem());
            return PartialView("_ClientScopeItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddClaim([Bind("Claims")] AddEditClientViewModel model)
        {
            model.Claims.Add(new ClientClaimItem());
            return PartialView("_ClientClaimItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSecret([Bind("Secrets")] AddEditClientViewModel model)
        {
            model.Secrets.Add(new SecretItem());
            return PartialView("_ClientSecretItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddProperty([Bind("Properties")] AddEditClientViewModel model)
        {
            model.Properties.Add(new PropertyItem());
            return PartialView("_ClientPropertyItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddGrantType([Bind("GrantTypes")] AddEditClientViewModel model)
        {
            model.GrantTypes.Add(new GrantTypeItem());
            return PartialView("_ClientGrantTypeItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCorsOrigin([Bind("CorsOrigins")] AddEditClientViewModel model)
        {
            model.CorsOrigins.Add(new CorsOriginItem());
            return PartialView("_ClientCorsOriginItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPostLogoutRedirectUri([Bind("PostLogoutRedirectUris")] AddEditClientViewModel model)
        {
            model.PostLogoutRedirectUris.Add(new PostLogoutRedirectUriItem());
            return PartialView("_ClientPostLogoutRedirectUriItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRedirectUri([Bind("RedirectUris")] AddEditClientViewModel model)
        {
            model.RedirectUris.Add(new RedirectUriItem());
            return PartialView("_ClientRedirectUriItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddRestriction([Bind("Restrictions")] AddEditClientViewModel model)
        {
            model.Restrictions.Add(new IdPRestrictionItem());
            return PartialView("_ClientIdPRestrictionItems", model);
        }
        #endregion
    }
}