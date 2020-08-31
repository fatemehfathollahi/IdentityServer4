using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
using Plus.Infrastructure.IdentityServer.Core.Domain.Service;
using Plus.Infrastructure.IdentityServer.Models;
using Plus.Infrastructure.IdentityServer.Models.ApiResource;

namespace Plus.Infrastructure.IdentityServer.Pages.Resource
{
    public class AddScopeModel : PageModel
    {
        private readonly IPlusApiResourceScopeService _apiResourceScopeService;


        public AddScopeModel(IPlusApiResourceScopeService resourceScopeService)
        {
            _apiResourceScopeService = resourceScopeService;
        }

        [BindProperty]
        public ApiResourceScopeViewModel Scope { get; set; }

        //public IEnumerable<ApiResourceScopeViewModel> Scopes { get; set; }
        public void OnGet()
        {
           
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            var _scope = new ApiResourceScope
            {
                Scope = Scope.Scope,
                ApiResourceId = Scope.ApiResourceId
            };

            _apiResourceScopeService.Insert(Scope.ApiResourceId, _scope);

            return RedirectToPage("Index");
        }
    }
}
