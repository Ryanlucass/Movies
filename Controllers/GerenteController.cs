using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class GerenteController : ControllerBase
    {
        private GerenteServices _service;

        public GerenteController(GerenteServices service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionarGerente( [FromBody] AddGerenteDto dto)
        {
            AddGerenteDto addGerente = _service.AdicionaGerente(dto);

            if (addGerente != null) { return CreatedAtAction(nameof(RecuperarGerentesPorId), new { Id = addGerente.Id }, addGerente); }
            else { return BadRequest(); }
            
        }

        [HttpGet]
        public IActionResult RecuperaGerentePorId()
        {
            var result = _service.RecupeGerente();
            
            return result != null ? Ok(result) : BadRequest("Não possui nenhum gerente");
            
        }

        [HttpGet ("{id}")]
        public IActionResult RecuperarGerentesPorId(int id)
        {
            var result = _service.RecupeGerentePorId(id);

            return result != null ? Ok(result) : NotFound($"O id: {id} não existe");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarGerente(int id)
        {
            var result = _service.DeletarGerente(id);

            return result != false ? NoContent() : NotFound("id não existe");
        }

    }
}
