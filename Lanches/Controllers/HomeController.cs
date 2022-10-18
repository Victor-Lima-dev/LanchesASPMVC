using Lanches.Context;
using Lanches.Models;
using Lanches.Models.ViewModels;
using Lanches.Repositorio;
using Lanches.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Lanches.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILancheRepositorio _lancheRepositorio;

        //Injeção do repositório de lanches
        public HomeController(ILancheRepositorio lancheRepositorio)
        {
            _lancheRepositorio = lancheRepositorio;
        }

        public IActionResult Index()
        {
            var HomeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepositorio.LanchesPreferidos
            };
            return View(HomeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}