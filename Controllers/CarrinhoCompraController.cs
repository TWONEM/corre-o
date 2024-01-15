using FloriculturaFlores.Models;
using FloriculturaFlores.Repositories.Interfaces;
using FloriculturaFlores.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FloriculturaFlores.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ICoroaRepository _coroaRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ICoroaRepository coroaRepository,
            CarrinhoCompra carrinhoCompra)
        {
            _coroaRepository = coroaRepository;
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

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int coroaId)
        {
            var coroaSelecionado = _coroaRepository.Coroas
                                    .FirstOrDefault(p => p.CoroaId == coroaId);

            if (coroaSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(coroaSelecionado);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int coroaId)
        {
            var coroaSelecionado = _coroaRepository.Coroas
                                    .FirstOrDefault(p => p.CoroaId == coroaId);

            if (coroaSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(coroaSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
