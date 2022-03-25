using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using FilmesAPI.Services;
using FilmesAPI.Api;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnderecoController : ControllerBase
    {
        private EnderecosServices _service;

        public EnderecoController(EnderecosServices service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] AddEnderecoDto addenderecodto)
        {

            AddEnderecoDto readDto = _service.AdicionaEndereco(addenderecodto);

            if (readDto != null) { return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = readDto.Id }, readDto); }
            else { return BadRequest(); }
        }

        [HttpGet]
        public IActionResult RecuperarEnderecos()
        {
            var result = _service.RecuperaEndereco();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecosPorId(int id)
        {
            var result = _service.RecuperaEnderecoPorId(id);
            if (result != null) { return Ok(result); } else { return BadRequest($"Id {id} informado, não existe");}
          
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto updateEnderecodto)
        {
            bool result = _service.AtualizarEnderecco(id, updateEnderecodto);

            return result != true ? NotFound($"Cheque o {id} informado") : NoContent(); 

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEndereco(int id)
        {
            bool result = _service.DeletarEndereco(id);
            return result != true ? NotFound($"Cheque o {id} informado") : NoContent();

        }

    }
}