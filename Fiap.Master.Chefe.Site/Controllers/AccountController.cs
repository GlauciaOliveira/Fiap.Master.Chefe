using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Fiap.Master.Chefe.Site.Models;
using Fiap.Master.Chefe.Site.Models.AccountViewModels;
using Fiap.Master.Chefe.Site.Services;
using Fiap.Master.Chefe.Core.Model;

namespace Fiap.Master.Chefe.Site.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuarios user) {



            return View();
        }
    }
}
