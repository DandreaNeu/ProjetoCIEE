using System.Threading.Tasks;

namespace Filmes.Persistence.Contratos
{
    public interface IGeralPersist
    {

        void Add<F>(F entity) where F : class;

        void Update<F>(F entity) where F : class;

        void Delete<F>(F entity) where F : class;

        void DeleteRange<F>(F[] entity) where F : class;

        Task<bool> SaveChangeAsync();
    }
};


