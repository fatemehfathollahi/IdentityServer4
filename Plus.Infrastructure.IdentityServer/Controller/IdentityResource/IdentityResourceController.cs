using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model =Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System;

namespace Plus.Infrastructure.IdentityServer.Controllers
{
    // [SecurityHeaders]
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
            var _identityResourceList = await _identityResourceService.GetAll();
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
            var model = new AddEditIdentityResourceViewModel
            {
                Created = DateTime.Now
            };
            return View("Create",model);
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
            await _identityResourceService.Insert(obj);
            return View("Success", model);
            // return View( Redirect("index"));
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var _model = await _identityResourceService.GetById(id);
            if (_model != null)
            {
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
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddEditIdentityResourceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var identityResource = await _identityResourceService.GetById(model.Id);
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

            await _identityResourceService.Update(identityResource);
            return View("Success", model);
            //  return View( Redirect("index"));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var _entity = await _identityResourceService.GetById(id);
            if (_entity != null)
            {
                var _model = new DeleteIdentityResourceViewModel
                {
                    Id = _entity.Id,
                    Name = _entity.Name
                };
                return View("Delete", _model);
            }
            return NotFound();
           
        }

        [HttpPost]
        public async Task<ActionResult> Delete(DeleteIdentityResourceViewModel model)
        {
            await _identityResourceService.Delete(model.Id);
            return Redirect("Index");
        }
    }
}