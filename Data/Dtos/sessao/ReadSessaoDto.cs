using FilmesAPI.Models;
using System;

namespace FilmesAPI.Data.Dtos
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public Filme Filme { get; set; }
        public int FilmeId { get; set; }
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }
        public DateTime HorarioDeInicio { get; set; }
    }
}
