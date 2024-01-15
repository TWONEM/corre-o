
using FloriculturaFlores.Models;

namespace FloriculturaFlores.Repositories.Interfaces
{
    public interface ICoroaRepository
    {
        IEnumerable<Coroa> Coroas { get; }
        IEnumerable<Coroa> CoroasPreferidos { get; }
        Coroa GetItemById(int coroaId);
    }
}
