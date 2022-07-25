using Filmes.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Persistence.Context;
using Filmes.Persistence.Contratos;

namespace Filmes.Persistence
{
    public class FilmePersist : IFilmePersist
    {

        private readonly FilmesContext _context;

        public FilmePersist(FilmesContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        
        public  async Task<Filme[]> GetAllFilmesAsync(bool includeGeneros = false)
        {
            IQueryable<Filme> query = _context.Filmes;

            if (includeGeneros)
            {
                query = query
                    .Include(f => f.GenerosFilmes)
                    .ThenInclude(gf => gf.Genero);
            }

            query = query.OrderBy(f => f.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Filme[]> GetAllFilmesByGeneroAsync(string genero, bool includeGeneros = false)
        {
                IQueryable<Filme> query = _context.Filmes;

                if (includeGeneros)
                {
                    query = query
                        .Include(f => f.GenerosFilmes)
                        .ThenInclude(gf => gf.Genero);
                }

                query = query.OrderBy(f => f.Id)
                             .Where(f => f.GeneroFilme.ToLower().Contains(genero.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Filme> GetAllFilmeByIDAsync(int filmeID, bool includeGeneros = false)
        {
            IQueryable<Filme> query = _context.Filmes;

            if (includeGeneros)
            {
                query = query
                    .Include(f => f.GenerosFilmes)
                    .ThenInclude(gf => gf.Genero);
            }

            query = query.OrderBy(f => f.Id)
                         .Where(f => f.Id == filmeID);

            return await query.FirstOrDefaultAsync();
        }


        
    }
}
