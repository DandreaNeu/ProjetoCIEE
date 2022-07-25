using Filmes.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filmes.Aplication.Contratos;

namespace Filmes.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmesController : ControllerBase
    {    
        private readonly IFilmeService _filmeService;
        public FilmesController(IFilmeService filmeService)
        {
           _filmeService = filmeService;
        }

        [HttpGet]

        public async Task <IActionResult> Get()
        {
            try
            {
               var filmes = await _filmeService.GetAllFilmesAsync(true); 
               if(filmes == null) return NotFound("Nenhum filme encontrado.");

               return Ok(filmes);
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var filme = await _filmeService.GetAllFilmeByIDAsync(id,true);
                if (filme == null) return NotFound("Filme não encontrado.");

                return Ok(filme);
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }    

        [HttpGet("{genero}/genero")]
        public async Task<IActionResult> GetByGenero(string genero)
        {
            try
            {
                var filme = await _filmeService.GetAllFilmesByGeneroAsync(genero,true);
                if (filme == null) return NotFound("Filme por gênero não encontrado.");

                return Ok(filme);
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Filme model)
        {
            try
            {
                var filme = await _filmeService.AddFilmes(model);
                if (filme == null) return BadRequest("Erro ao adicionar novo filme.");

                return Ok(filme);
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }

        }
        [HttpPut ("{id}")]
        public async Task<IActionResult> Put(int id , Filme model)
        {
            try
            {
                var filme = await _filmeService.UpdateFilmes(id ,model );
                if (filme == null) return BadRequest("Erro ao atualizar filme.");

                return Ok(filme);
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>  Delete(int id)
        {
            try
            {
                return await _filmeService.DeleteFilmes(id) ?
                       Ok("Filme excluído.") :
                       BadRequest("Filme não excluído.");           
                    
            }
            catch (Exception error)
            {
                return this.StatusCode(500, error);
            }

        }
    }
}
