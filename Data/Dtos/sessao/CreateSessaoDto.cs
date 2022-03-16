using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class CreateSessaoDto
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public Cinema Cinema { get; set; }
        public Filme Filme { get; set; }
    }
}
