using FloriculturaFlores.Context;
using FloriculturaFlores.Models;
using FloriculturaFlores.Repositories.Interfaces;
using static FloriculturaFlores.Context.AppDbContext;

namespace FloriculturaFlores.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

