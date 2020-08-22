using IdentityServer4.Events;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Plus.Infrastructure.IdentityServer.Core.Domain.Models;
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
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;
        //private readonly IPlusClientService _clientService;

        public ClientController(//IPlusClientService clientService,
            ILogger<ClientController> logger)
        {
           // _clientService = clientService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           // var _allClient = _clientService.GetAll();

            var vm = new List<ClientViewModel>();
            //_allClient.ToList().ForEach(client => vm.Add(new ClientViewModel
            //{
            //    ClientId = client.ClientId,
            //   // AllowedScopes = client.AllowedScopes,
            //  //  AllowedGrantTypes = client.AllowedGrantTypes,

            //})); 
            
            return View("AllClient", vm);
        }

    }
}