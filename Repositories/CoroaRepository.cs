using FloriculturaFlores.Context;
using FloriculturaFlores.Models;
using FloriculturaFlores.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FloriculturaFlores.Repositories
{
    public class CoroaRepository : ICoroaRepository
    {
        private readonly AppDbContext _context;
        public CoroaRepository(AppDbContext contexto)
        {
            _context = contexto; 
        }
        public IEnumerable<Coroa> Coroas => _context.Coroas.Include(c => c.Categoria);
        public IEnumerable<Coroa> CoroasPreferidos => _context.Coroas
            .Where(l => l.IsCoroaPreferido)
            .Include(c => c.Categoria);

        public Coroa GetItemById(int coroaId)
        {
            return _context.Coroas.FirstOrDefault(l => l.CoroaId == coroaId);
        }
    }
}
