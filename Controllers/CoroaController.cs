using FloriculturaFlores.Models;
using FloriculturaFlores.Repositories.Interfaces;
using FloriculturaFlores.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FloriculturaFlores.Controllers
{
    public class CoroaController : Controller
    {
        public readonly ICoroaRepository _coroaRepository;

        public CoroaController(ICoroaRepository coroaRepository)
        {
            _coroaRepository = coroaRepository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Coroa> coroas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria)) 
            {
                coroas = _coroaRepository.Coroas.OrderBy(l => l.CoroaId);
                categoriaAtual = "Todas as Coroas";
            }
            else 
            {
                //if(string.Equals("Simples", categoria, StringComparison.OrdinalIgnoreCase)) 
                //{
                //    coroas = _coroaRepository.Coroas
                //        .Where(l => l.Categoria.CategoriaNome.Equals("Simples"))
                //        .OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    coroas = _coroaRepository.Coroas
                //        .Where(l => l.Categoria.CategoriaNome.Equals("Luxo"))
                //        .OrderBy(l => l.Nome);
                //}
                //categoriaAtual = categoria;

                coroas = _coroaRepository.Coroas
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);

            }

            var coroaListViewModel = new CoroaListViewModel
            {
                Coroas = coroas,
                CategoriaAtual = categoriaAtual,
            };
          
            return View(coroaListViewModel);

        }
        public IActionResult Details(int coroaId)
        {
            var coroa = _coroaRepository.Coroas.FirstOrDefault(l => l.CoroaId == coroaId);
            return View(coroa);
        }
        public ViewResult Search(string searchString)
        {
            IEnumerable<Coroa> coroas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                coroas = _coroaRepository.Coroas.OrderBy(p => p.CoroaId);
                categoriaAtual = "Todas as Coroas";
            }
            else
            {
                coroas = _coroaRepository.Coroas
                          .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (coroas.Any())
                    categoriaAtual = "Coroas";
                else
                    categoriaAtual = "Nenhuma Coroa foi encontrada";
            }

            return View("~/Views/Coroa/List.cshtml", new CoroaListViewModel
            {
                Coroas = coroas,
                CategoriaAtual = categoriaAtual
            });
        }
    }
}
