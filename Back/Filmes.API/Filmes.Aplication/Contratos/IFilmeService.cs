using Filmes.Domain;
using System.Threading.Tasks;

namespace Filmes.Aplication.Contratos
{
    public interface IFilmeService
    {
        Task<Filme> AddFilmes(Filme model);

        Task<Filme> UpdateFilmes(int filmeId , Filme model);

        Task<bool> DeleteFilmes(int filmeId);

        Task<Filme[]> GetAllFilmesAsync(bool includeGeneros = false);

        Task<Filme[]> GetAllFilmesByGeneroAsync(string genero, bool includeGeneros = false);

        Task<Filme> GetAllFilmeByIDAsync(int filmeID, bool includeGeneros = false);
    }
}
