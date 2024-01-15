using FloriculturaFlores.Models;
using FloriculturaFlores.Repositories.Interfaces;
using FloriculturaFlores.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FloriculturaFlores.Controllers
{
    public class HomeController : Controller
    {
        public readonly ICoroaRepository _coroaRepository;

        public HomeController(ICoroaRepository coroaRepository)
        {
            _coroaRepository = coroaRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                CoroasPreferidos = _coroaRepository.CoroasPreferidos
            };
            return View(homeViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id 
                ?? HttpContext.TraceIdentifier
            });
        }
    }
}
