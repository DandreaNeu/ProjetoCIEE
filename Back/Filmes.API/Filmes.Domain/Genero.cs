using System.Collections.Generic;

namespace Filmes.Domain
{
    public class Genero
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<GenerosFilmes> GenerosFilmes { get; set; }
    }
}
