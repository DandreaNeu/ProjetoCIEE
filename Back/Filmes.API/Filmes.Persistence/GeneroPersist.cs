using Filmes.Domain;
using Filmes.Persistence.Context;
using Filmes.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Filmes.Persistence
{
    public class GeneroPersist : IGeneroPersist
    {

        private readonly FilmesContext _context;

        public GeneroPersist(FilmesContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public async Task<Genero[]> GetAllGenerosAsync(bool includeFilmes = false)
        {
            IQueryable<Genero> query = _context.Generos;

            if (includeFilmes)
            {
                query = query
                    .Include(g => g.GenerosFilmes)
                    .ThenInclude(gf => gf.Filme);
            }

            query = query.OrderBy(g => g.Id);

            return await query.ToArrayAsync();
        }
                              
        public async Task<Genero[]> GetAllGenerosByNomeAsync(string nome, bool includeFilmes = false)
        {
            IQueryable<Genero> query = _context.Generos;

            if (includeFilmes)
            {
                query = query
                    .Include(g => g.GenerosFilmes)
                    .ThenInclude(gf => gf.Filme);
            }

            query = query.OrderBy(g => g.Id)
                         .Where(g => g.Name.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Genero> GetAllGeneroByIDAsync(int generoID, bool includeFilmes = false)
        {
            IQueryable<Genero> query = _context.Generos;

            if (includeFilmes)
            {
                query = query
                    .Include(g => g.GenerosFilmes)
                    .ThenInclude(gf => gf.Filme);
            }

            query = query.OrderBy(g => g.Id)
                         .Where(g => g.Id == generoID);

            return await query.FirstOrDefaultAsync();
        }
    }
}
