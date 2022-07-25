using Filmes.Domain;
using System.Threading.Tasks;

namespace Filmes.Persistence.Contratos
{
    public interface IFilmePersist
    {
        Task<Filme[]> GetAllFilmesAsync(bool includeGeneros = false);

        Task<Filme[]> GetAllFilmesByGeneroAsync(string genero, bool includeGeneros = false);
                
        Task<Filme> GetAllFilmeByIDAsync(int filmeID, bool includeGeneros = false);

    }
}
