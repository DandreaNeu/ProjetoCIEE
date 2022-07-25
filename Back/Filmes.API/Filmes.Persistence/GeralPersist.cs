using Filmes.Persistence.Context;
using Filmes.Persistence.Contratos;
using System.Threading.Tasks;

namespace Filmes.Persistence
{
    public class GeralPersist : IGeralPersist
    {

        private readonly FilmesContext _context;

        public GeralPersist(FilmesContext context)
        {
            _context = context;
        }
        public void Add<F>(F entity) where F : class
        {
            _context.Add(entity);
        }

        public void Update<F>(F entity) where F : class
        {
            _context.Update(entity);

        }

        public void Delete<F>(F entity) where F : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<F>(F[] entityArray) where F : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0; 
        }
        
    }
}
