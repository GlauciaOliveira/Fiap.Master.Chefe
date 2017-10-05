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
using System.Net.Http;

namespace Fiap.Master.Chefe.Site.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {


        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Core.Model.Usuarios user)
        {
            string apiUrl = "http://localhost:58764/api/values";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                    if (user != null)
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.Login));
                        var id = new ClaimsIdentity(claims, "password");
                        var principal = new ClaimsPrincipal(id);

                        await HttpContext.SignInAsync("app", principal);
                    }
                }
            }
            
            return View();
        }

        public IActionResult Forbidden()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("app");

            return RedirectToAction("Index", "Home");
        }
    }
}
