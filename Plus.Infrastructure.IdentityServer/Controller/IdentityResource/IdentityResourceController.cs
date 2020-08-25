using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model =Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plus.Infrastructure.IdentityServer.Controllers
{
    /// <summary>
    /// This controller processes the client UI
    /// </summary>
    [SecurityHeaders]
    [AllowAnonymous]
    public class IdentityResourceController : Controller
    {
        private readonly ILogger<IdentityResourceController> _logger;
        private readonly IPlusIdentityResourceService _identityResourceService;

        public IdentityResourceController(IPlusIdentityResourceService identityResourceService,
            ILogger<IdentityResourceController> logger)
        {
            _identityResourceService = identityResourceService;
            _logger = logger; 
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var _identityResourceList = _identityResourceService.GetAll();
            var _vm = new List<IdentityResourceViewModel>();

            _identityResourceList.ToList().ForEach(model => _vm.Add(new IdentityResourceViewModel
            {
               Id = model.Id,
               Enabled = model.Enabled,
               Emphasize = model.Emphasize,
               ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
               Name = model.Name,
               Description = model.Description,
               DisplayName = model.DisplayName,
               NonEditable = model.NonEditable,
               Created = model.Created,
               Updated = model.Updated,
               Required = model.Required
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
        public async Task<IActionResult> Create(AddEditIdentityResourceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var obj = new Model.IdentityResource
            {
                Enabled = model.Enabled,
                Name = model.Name,
                Description = model.Description,
                DisplayName = model.DisplayName,
                Required = model.Required,
                Emphasize = model.Emphasize,
                ShowInDiscoveryDocument = model.ShowInDiscoveryDocument,
                Created = model.Created,
                Updated = model.Updated,
                NonEditable = model.NonEditable
            };
            _identityResourceService.Insert(obj);
            return View("Success", model);
            // return View( Redirect("index"));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var _model = _identityResourceService.GetById(id);

                var vm = new AddEditIdentityResourceViewModel
                {
                    Id = _model.Id,
                    Enabled = _model.Enabled,
                    Name = _model.Name,
                    Description = _model.Description,
                    DisplayName = _model.DisplayName,
                    Required = _model.Required,
                    Emphasize = _model.Emphasize,
                    ShowInDiscoveryDocument = _model.ShowInDiscoveryDocument,
                    Created = _model.Created,
                    Updated = _model.Updated,
                    NonEditable = _model.NonEditable
                };
                return View("Edit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddEditIdentityResourceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var identityResource = _identityResourceService.GetById(model.Id);
            identityResource.Name = model.Name;
            identityResource.DisplayName = model.DisplayName;
            identityResource.Description = model.Description;
            identityResource.Emphasize = model.Emphasize;
            identityResource.Enabled = model.Enabled;
            identityResource.NonEditable = model.NonEditable;
            identityResource.Required = model.Required;
            identityResource.ShowInDiscoveryDocument = model.ShowInDiscoveryDocument;
            identityResource.Created = model.Created;
            identityResource.Updated = model.Updated;

            _identityResourceService.Update(identityResource);
             return View( Redirect("index"));
        }



    }
}