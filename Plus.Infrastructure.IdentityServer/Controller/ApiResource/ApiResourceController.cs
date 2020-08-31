using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Models.ApiResource;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Controllers
{
    [SecurityHeaders]
    [AllowAnonymous]
    public class ApiResourceController : Controller
    {
        private readonly ILogger<ApiResourceController> _logger;
        private readonly IPlusApiResourceService _apiResourceService;
        private readonly IPlusApiResourceScopeService _apiResourceScopeService;
        private readonly IPlusApiResourceSecretService _apiResourceSecretService;
        private readonly IPlusApiResourceClaimService _apiResourceClaimService;
        private readonly IPlusApiResourcePropertyService _apiResourcePropertyService;

        public ApiResourceController(IPlusApiResourceService apiResourceService,
            IPlusApiResourceScopeService apiResourceScopeService,
            IPlusApiResourceSecretService apiResourceSecretService,
             IPlusApiResourceClaimService apiResourceClaimService,
             IPlusApiResourcePropertyService apiResourcePropertyService,
            ILogger<ApiResourceController> logger)
        {
            _apiResourceService = apiResourceService;
            _apiResourceScopeService = apiResourceScopeService;
            _apiResourceSecretService = apiResourceSecretService;
            _apiResourceClaimService = apiResourceClaimService;
            _apiResourcePropertyService = apiResourcePropertyService;
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
                LastAccessed = model.LastAccessed

            }));

            var _vmScope = new List<ApiResourceScopeViewModel>();



            _vm.ForEach(v => v.Scopes =  _apiResourceScopeService.GetScopesByResourceId(v.Id)
            .ToList().Select(s => new ApiResourceScopeViewModel
            {
                Id = s.Id,
                Scope = s.Scope,
                ApiResourceId = v.Id
            }));

            _vm.ForEach(v => v.Secrets = _apiResourceSecretService.GetSecretsByResourceId(v.Id)
           .ToList().Select(s => new ApiResourceSecretViewModel
           {
               Id = s.Id,
               Description = s.Description,
               Value = s.Value,
               Expiration = s.Expiration,
               Type = s.Type,
               Created = s.Created,
               ApiResourceId = v.Id
           }));

            _vm.ForEach(v => v.UserClaims = _apiResourceClaimService.GetClaimsByResourceId(v.Id)
           .ToList().Select(s => new ApiResourceClaimViewModel
           {
               Id = s.Id,
               Type = s.Type,
               ApiResourceId = v.Id
           }));

        _vm.ForEach(v => v.Properties = _apiResourcePropertyService.GetPropertiesByResourceId(v.Id)
        .ToList().Select(s => new ApiResourcePropertyViewModel
        {
            Id = s.Id,
            Key = s.Key,
            Value = s.Value,
            ApiResourceId = v.Id
        }));
            //foreach (var resource in _apiResourceList)
            //{
            //    var _resourceScopeList = _apiResourceScopeService.GetScopesByResourceId(resource.Id);

            //    _resourceScopeList.ToList().ForEach(model => _vmScope.Add(new ApiResourceScopeViewModel
            //    {
            //        Id = model.Id,
            //        Scope = model.Scope,
            //        ApiResourceId = model.ApiResourceId
            //    }));

            //}

            // _vm.ForEach(v => v.Scopes = _vmScope);
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
                NonEditable = model.NonEditable
            };
            _apiResourceService.Insert(obj);
            return View("Success", model);
            // return View( Redirect("index"));
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
                    NonEditable = _model.NonEditable
                };
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

            _apiResourceService.Update(apiResource);
            return View("Success", model);
            //  return View( Redirect("index"));
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
    }
}