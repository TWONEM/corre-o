using FloriculturaFlores.Models;

namespace FloriculturaFlores.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
