using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Models;
using Plus.Infrastructure.IdentityServer.Models.ApiResource;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Controllers
{
   // [SecurityHeaders]
    [AllowAnonymous]
    public class ApiResourceController : Controller
    {
        private readonly ILogger<ApiResourceController> _logger;
        private readonly IPlusApiResourceService _apiResourceService;

        public ApiResourceController(IPlusApiResourceService apiResourceService,
            ILogger<ApiResourceController> logger)
        {
            _apiResourceService = apiResourceService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _apiResourceList = _apiResourceService.GetAll();
            var _vm = new List<ApiResourceViewModel>();

            _apiResourceList.ToList().ForEach(model => _vm.Add(new ApiResourceViewModel
            {
                Id = model.Id,
                Enabled = model.Enabled,
                Name = model.Name,
                Description = model.Description,
                DisplayName = model.DisplayName,
                NonEditable = model.NonEditable,
                Created = model.Created,
                Updated = model.Updated,
                LastAccessed = model.LastAccessed,
                AllowedAccessTokenSigningAlgorithms = model.AllowedAccessTokenSigningAlgorithms,
                ShowInDiscoveryDocument = model.ShowInDiscoveryDocument
            }));

            
            _vm.ForEach(v => v.Scopes = _apiResourceService.GetScopesByResourceId(v.Id)
            .ToList().Select(s => new ScopeItem
            {
                Id = s.Id,
                Scope = s.Scope
            }));

            _vm.ForEach(v => v.Secrets = _apiResourceService.GetSecretsByResourceId(v.Id)
           .ToList().Select(s => new SecretItem
           {
               Id = s.Id,
               Value = s.Value,
               Type = s.Type,
               Description = s.Description,
               Expiration = s.Expiration,
               Created = s.Created
           }));

            _vm.ForEach(v => v.UserClaims = _apiResourceService.GetClaimsByResourceId(v.Id)
          .ToList().Select(s => new ClaimItem
          {
              Id = s.Id,
              Type = s.Type
          }));

            _vm.ForEach(v => v.Properties = _apiResourceService.GetPropertiesByResourceId(v.Id)
       .ToList().Select(s => new PropertyItem
       {
           Id = s.Id,
           Key = s.Key,
           Value = s.Value
       }));

            return View("Index", _vm);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddEditApiResourceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = new Core.Domain.Models.ApiResource
            {
                Enabled = model.Enabled,
                Name = model.Name,
                Description = model.Description,
                DisplayName = model.DisplayName,
                LastAccessed = model.LastAccessed,
                Created = model.Created,
                Updated = model.Updated,
                NonEditable = model.NonEditable,
                ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
                AllowedAccessTokenSigningAlgorithms = model.AllowedAccessTokenSigningAlgorithms
            };

            var _resourceId = _apiResourceService.Insert(obj);


            model.Scopes.ForEach(s => _apiResourceService.AddScope(
               new Core.Domain.Models.ApiResourceScope
               {
                   ApiResourceId = _resourceId,
                   Scope = s.Scope
               }));

            model.Secrets.ForEach(s => _apiResourceService.AddSecret(
              new Core.Domain.Models.ApiResourceSecret
              {
                  ApiResourceId = _resourceId,
                  Description = s.Description,
                  Value = s.Value,
                  Type = s.Type,
                  Created = s.Created,
                  Expiration = s.Expiration
              }));

            model.Claims.ForEach(s => _apiResourceService.AddClaim(
              new Core.Domain.Models.ApiResourceClaim
              {
                  ApiResourceId = _resourceId,
                  Type = s.Type
              }));

            model.Properties.ForEach(s => _apiResourceService.AddProperty(
              new Core.Domain.Models.ApiResourceProperty
              {
                  ApiResourceId = _resourceId,
                  Value = s.Value,
                  Key = s.Key
              }));

            ViewBag.Message = "Created";
            return View("Success", model);
            // return Redirect("index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var _model = _apiResourceService.GetById(id);
            if (_model != null)
            {
                var vm = new AddEditApiResourceViewModel
                {
                    Id = _model.Id,
                    Enabled = _model.Enabled,
                    Name = _model.Name,
                    Description = _model.Description,
                    DisplayName = _model.DisplayName,
                    LastAccessed = _model.LastAccessed,
                    Created = _model.Created,
                    Updated = _model.Updated,
                    NonEditable = _model.NonEditable,
                    ShowInDiscoveryDocument = _model.ShowInDiscoveryDocument,
                    AllowedAccessTokenSigningAlgorithms = _model.AllowedAccessTokenSigningAlgorithms,
                };

                _model.Scopes.ForEach(s => vm.Scopes.Add(new ScopeItem
                {
                    Id = s.Id,
                    Scope = s.Scope
                }));

                _model.Secrets.ForEach(s => vm.Secrets.Add(new SecretItem
                {
                    Id = s.Id,
                    Value = s.Value,
                    Description = s.Description,
                    Type = s.Type,
                    Created = s.Created,
                    Expiration = s.Expiration
                }));

                _model.UserClaims.ForEach(s => vm.Claims.Add(new ClaimItem
                {
                    Id = s.Id,
                    Type = s.Type
                }));

                _model.Properties.ForEach(s => vm.Properties.Add(new PropertyItem
                {
                    Id = s.Id,
                    Key = s.Key,
                    Value = s.Value
                }));

                
                return View("Edit", vm);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddEditApiResourceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var apiResource = _apiResourceService.GetById(model.Id);
            apiResource.Name = model.Name;
            apiResource.DisplayName = model.DisplayName;
            apiResource.Description = model.Description;
            apiResource.Enabled = model.Enabled;
            apiResource.NonEditable = model.NonEditable;
            apiResource.Created = model.Created;
            apiResource.Updated = model.Updated;
            apiResource.LastAccessed = model.LastAccessed;
            apiResource.AllowedAccessTokenSigningAlgorithms = model.AllowedAccessTokenSigningAlgorithms;
            apiResource.ShowInDiscoveryDocument = model.ShowInDiscoveryDocument;

            var _resourceId = _apiResourceService.Update(apiResource);

           

            foreach (var scope in model.Scopes)
            {
                var _scope = apiResource.Scopes.Where(s => s.Id.Equals(scope.Id)).FirstOrDefault();
                _scope.Scope = scope.Scope;
                _apiResourceService.UpdateScope(_scope);
            }

            foreach (var secret in model.Secrets)
            {
                var _secret = apiResource.Secrets.Where(s => s.Id.Equals(secret.Id)).FirstOrDefault();
                _secret.Value = secret.Value;
                _secret.Description = secret.Description;
                _secret.Type = secret.Type;
                _secret.Created = secret.Created;
                _secret.Expiration = secret.Expiration;
                _secret.ApiResourceId = _resourceId;
                _apiResourceService.UpdateSecret(_secret);
            }

            foreach (var claim in model.Claims)
            {
                var _claim = apiResource.UserClaims.Where(s => s.Id.Equals(claim.Id)).FirstOrDefault();
                _claim.Type = claim.Type;
                _apiResourceService.UpdateClaim(_claim);
            }

            foreach (var property in model.Properties)
            {
                var _property = apiResource.Properties.Where(s => s.Id.Equals(property.Id)).FirstOrDefault();
                _property.Key = property.Key;
                _property.Value = property.Value;
                _apiResourceService.UpdateProperty(_property);
            }

            ViewBag.Message = "Edited";
            return View("Success", model);
            // return Redirect("index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var _entity = _apiResourceService.GetById(id);
            if (_entity != null)
            {
                var _model = new DeleteApiResourceViewModel
                {
                    Id = _entity.Id,
                    Name = _entity.Name
                };
                return View("Delete", _model);
            }
            return NotFound();

        }

        [HttpPost]
        public async Task<ActionResult> Delete(DeleteApiResourceViewModel model)
        {
            _apiResourceService.Delete(model.Id);
            return Redirect("Index");
        }

        #region EditorFor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddScope([Bind("Scopes")] AddEditApiResourceViewModel model)
        {
            model.Scopes.Add(new ScopeItem());
            return PartialView("_ScopeItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddClaim([Bind("Claims")] AddEditApiResourceViewModel model)
        {
            model.Claims.Add(new ClaimItem());
            return PartialView("_ClaimItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSecret([Bind("Secrets")] AddEditApiResourceViewModel model)
        {
            model.Secrets.Add(new SecretItem());
            return PartialView("_SecretItems", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddProperty([Bind("Properties")] AddEditApiResourceViewModel model)
        {
            model.Properties.Add(new PropertyItem());
            return PartialView("_PropertyItems", model);
        }
        #endregion
    }
}