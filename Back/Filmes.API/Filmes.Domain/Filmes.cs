using System;
using System.Collections.Generic;

namespace Filmes.Domain
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public DateTime? DataLancamento { get; set; }

        public string GeneroFilme { get; set; }

        public string Diretor { get; set; }

        public string ListaAtores { get; set; }

        public IEnumerable<GenerosFilmes>GenerosFilmes { get; set; }   


    }
}
