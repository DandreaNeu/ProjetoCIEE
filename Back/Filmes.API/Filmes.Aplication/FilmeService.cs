using Filmes.Aplication.Contratos;
using Filmes.Domain;
using Filmes.Persistence;
using Filmes.Persistence.Contratos;
using System;
using System.Threading.Tasks;

namespace Filmes.Aplication
{
    public class FilmeService : IFilmeService
    {
        private readonly IGeralPersist _geralPersist;

        private readonly IFilmePersist _filmePersist;


        public FilmeService(IGeralPersist geralPersist, IFilmePersist filmePersist)
        {
            _geralPersist = geralPersist;
            _filmePersist = (IFilmePersist)filmePersist;

        }

        public IFilmePersist FilmePersit { get; }

        public async Task<Filme> AddFilmes(Filme model)
        {
            try
            {
                _geralPersist.Add<Filme>(model);
                if(await _geralPersist.SaveChangeAsync())
                {
                    return await _filmePersist.GetAllFilmeByIDAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception error)
            {
                throw new Exception (error.Message);
            }
           
        }
        public async Task<Filme> UpdateFilmes(int filmeId, Filme model)
        {
            try
            {
                var filme = await _filmePersist.GetAllFilmeByIDAsync(filmeId, false);
                if(filme == null)   return null;

                model.Id = filme.Id;

                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangeAsync())
                {
                    return await _filmePersist.GetAllFilmeByIDAsync(model.Id, false);
                }
                return null;

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public async Task<bool> DeleteFilmes(int filmeId)
        {
            try
            {
                var filme = await _filmePersist.GetAllFilmeByIDAsync(filmeId, false);
                if (filme == null)
                {
                    throw new Exception("Filme para excluir,não foi encontrado.");
                }

                _geralPersist.Delete(filme);
                return await _geralPersist.SaveChangeAsync();


            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public async Task<Filme[]> GetAllFilmesAsync(bool includeGeneros = false)
        {
            try
            {
                var filmes = await _filmePersist.GetAllFilmesAsync(includeGeneros);
                if (filmes == null) return null;
                return filmes;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public async Task<Filme[]> GetAllFilmesByGeneroAsync(string genero, bool includeGeneros = false)
        {
            try
            {
                var filmes = await _filmePersist.GetAllFilmesByGeneroAsync(genero, includeGeneros);
                if (filmes == null) return null;
                return filmes;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }
        public async Task<Filme> GetAllFilmeByIDAsync(int filmeID, bool includeGeneros = false)
        {
            try
            {
                var filmes = await _filmePersist.GetAllFilmeByIDAsync(filmeID, includeGeneros);
                if (filmes == null) return null;
                return filmes;
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }               

       
    }
}
