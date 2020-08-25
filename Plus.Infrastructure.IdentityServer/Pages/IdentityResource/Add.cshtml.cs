using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Models;

namespace Plus.Infrastructure.IdentityServer.Pages.IdentityResource
{
    public class AddModel : PageModel
    {
        private readonly IPlusIdentityResourceService _identityResourceService;


        public AddModel(IPlusIdentityResourceService identityResourceService)
        {
            _identityResourceService = _identityResourceService;
        }

        [BindProperty]
        public AddEditIdentityResourceViewModel Model { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var obj = new Core.Domain.Models.IdentityResource
            {
                Enabled = Model.Enabled,
                Name = Model.Name,
                Description = Model.Description,
                DisplayName = Model.DisplayName,
                Required = Model.Required,
                Emphasize = Model.Emphasize,
                ShowInDiscoveryDocument = Model.ShowInDiscoveryDocument,
                Created = Model.Created,
                Updated = Model.Updated,
                NonEditable = Model.NonEditable
            };
            _identityResourceService.Insert(obj);

            return RedirectToPage("Index");
        }
    }
}
