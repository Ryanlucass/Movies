using FilmesAPI.Data.Dtos;
using FilmesAPI.Interfaces;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmesService _filmeService;
        private readonly IFilmeRepository repository;

        public FilmeController(FilmesService filmeService, IFilmeRepository repository)
        {
            _filmeService = filmeService;
            this.repository = repository;
        }

        /// <summary>
        /// Cadastrando Filme
        /// </summary>
        /// <param name="filmeDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] AddFilmeDto filmeDto)
        {
        
            AddFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);

            if(readDto != null) { return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id }, readDto); }
            else { return BadRequest(); }

        }

        /// <summary>
        /// Recuperando filmes totais ou por classificação etária 
        /// </summary>
        /// <param name="classificacaoEtaria"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult RecuperarFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<Filme> filmes = repository.RecuperaFilmes(classificacaoEtaria);

            return filmes != null ? Ok(filmes) : NotFound($"Não existe filme com classificação etária igual a : {classificacaoEtaria}");
        }

        /// <summary>
        /// recuperando filme por id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto readDto = _filmeService.RecuperaFilmesPorId(id);

            return readDto != null ? Ok(readDto) : NotFound($"O id: {id} não existe");
        }


        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto updatefilmedto)
        {

            var result = _filmeService.AtualizarFilme(id ,updatefilmedto);

            if (result != true) { return NotFound($"cheque o {id} informado"); } else { return NoContent(); }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id)
        {
            var result = _filmeService.DeletarFilme(id);

            return result != true ? NotFound("id não existe") : NoContent();
        }
    }
}
