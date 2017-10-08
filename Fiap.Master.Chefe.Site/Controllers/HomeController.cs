using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fiap.Master.Chefe.Site.Models;
using Fiap.Master.Chefe.Core.Model;

namespace Fiap.Master.Chefe.Site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Somos um canal facilitador.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Dados para cotato.";

            return View();
        }

        public IActionResult Cadastro()
        {
            ViewData["Message"] = "Envio de Receitas";
            return View();
        }

        public IActionResult Consulta()
        {
            ViewData["Message"] = "Consulta de Receitas";
            
            return View();
        }

        public IActionResult CadastroUsuario()
        {
            ViewData["Message"] = "Cadastre-se";
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
