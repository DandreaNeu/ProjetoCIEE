using Filmes.Domain;
using System.Threading.Tasks;

namespace Filmes.Persistence.Contratos
{
    public interface IGeneroPersist
    {


        Task<Genero[]> GetAllGenerosByNomeAsync(string nome, bool includeFilmes);

        Task<Genero[]> GetAllGenerosAsync(bool includeFilmes);

        Task<Genero> GetAllGeneroByIDAsync(int generoId, bool includeFilmes);

    }
}
