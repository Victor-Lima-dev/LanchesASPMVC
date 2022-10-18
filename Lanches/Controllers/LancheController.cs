using Lanches.Models.NovaPasta;
using Lanches.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Controllers
{
    public class LancheController : Controller
    {


        private readonly ILancheRepositorio _lancheRepositorio;

        public LancheController(ILancheRepositorio lancheRepositorio)
        {
            _lancheRepositorio = lancheRepositorio;
        }

        public IActionResult List()
        {

            //var lanches = _lancheRepositorio.Lanches;
            //return View(lanches);

            var LancheViewModel = new LancheViewModel();
            LancheViewModel.Lanches = _lancheRepositorio.Lanches;
            LancheViewModel.CategoriaAtual = "Categoria B";

            return View(LancheViewModel);
        }
    }
}
