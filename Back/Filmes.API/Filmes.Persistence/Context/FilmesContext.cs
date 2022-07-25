using Filmes.Domain;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Persistence.Context
{
    public class FilmesContext : DbContext
    {
        public FilmesContext(DbContextOptions<FilmesContext> option) : base(option) { }
        public DbSet<Filme> Filmes { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<GenerosFilmes> GenerosFilmes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenerosFilmes>()
                .HasKey(GF => new { GF.FilmeId, GF.GeneroId });
        }
    }
}
