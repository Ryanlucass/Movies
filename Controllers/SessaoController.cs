using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Interfaces;
using FilmesAPI.Models;
using FilmesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private SessaoServices _service;
        private readonly ISessaoRepository repository;

        public SessaoController(SessaoServices service, ISessaoRepository repository)
        {
            this.repository = repository;
            _service = service;
        }


        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto dto)
        {
            var result = _service.AdicionaSessao(dto);

            if (result != null) { return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = result.Id }, result); }
            else { return BadRequest(); }
        }

        //[HttpPost]
        //public IActionResult AdicionaSessao([FromBody] CreateSessaoDto dto)
        //{
        //    var result = repository.AdicionaSessao(dto);

        //    if (result != null) { return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = result.Id }, result); }
        //    else { return BadRequest(); }
        //}

        [HttpGet]
        public IActionResult RecuperarSessao()
        {
            var result = _service.RecuperaSessao();

            return result != null ? Ok(result) : BadRequest();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            var readDto = _service.RecuperaSessaoPorId(id);

            return readDto != null ? Ok(readDto) : NotFound($"O id: {id} não existe");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarSessao(int id)
        {
            bool result = _service.DeletarSessao(id);

            return result != false ? Ok(result) : NotFound($"{id}");
        }
    }
}
