using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using FilmesAPI.Services;
using FilmesAPI.Interfaces;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CinemaController : ControllerBase
    {
        private CinemaServices _service;

        private readonly ICinemaRepository repository;


        public CinemaController(CinemaServices service, ICinemaRepository repository)
        {
            this.repository = repository;
            _service = service;
        }


        [HttpPost]
        public IActionResult AdicionarCinema([FromBody] AddCinemaDto cinemadto)
        {
            AddCinemaDto readDto = _service.AdicionaCinema(cinemadto);

            if(readDto != null) { return NoContent();}
            else { return BadRequest(); }
        }



        //[HttpGet]
        //public IActionResult RecuperarCinemas([FromQuery] string nomefilme)
        //{
        //    var result = _service.RecuperarCinema(nomefilme);

        //    return result != null ? Ok(result) : NotFound("Não existe nenhuma lista");

        //}

        [HttpGet]
        public IActionResult RecuperarCinemas([FromQuery] string nomefilme)
        {
            var result = repository.RecuperarCinema(nomefilme);

            return result != null ? Ok(result) : NotFound("Não existe nenhuma lista");

        }


        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            var result = _service.RecuperarCinemaPorId(id);
            return result != null ? Ok(result) : NotFound($"O id: {id} não existe");
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            bool result = _service.DeletarCinema(id);

            return result != false ? Ok("excluído com sucesso") : NotFound($" o id: {id} não existe");
        }

    }
}
