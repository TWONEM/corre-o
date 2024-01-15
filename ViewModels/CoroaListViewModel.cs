using FloriculturaFlores.Models;

namespace FloriculturaFlores.ViewModels
{
    public class CoroaListViewModel
    {
        public IEnumerable<Coroa> Coroas { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
