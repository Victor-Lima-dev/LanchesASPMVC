using Lanches.Models;
using Lanches.Models.ViewModels;
using Lanches.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lanches.Controllers
{
    public class CarrinhoComprarController : Controller
    {

        private readonly ILancheRepositorio _lancheRepositorio;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoComprarController(ILancheRepositorio lancheRepositorio, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepositorio = lancheRepositorio;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepositorio.Lanches.FirstOrDefault(s => s.LancheId == lancheId);
            if(lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverItemDoCarrinhoCompra(int lancheId)
        {
            var lancheSelecionado = _lancheRepositorio.Lanches.FirstOrDefault(s => s.LancheId == lancheId);
            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
