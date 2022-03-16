using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Interfaces
{
    public interface ICinemaRepository
    {
        public AddCinemaDto AdicionaCinema(AddCinemaDto addcinemaDto);
        public List<CinemadtoDapper> RecuperarCinema(string nomecinema);
        public ReadCinemaDto RecuperarCinemaPorId(int id);
        public bool DeletarCinema(int id);
    }
}

