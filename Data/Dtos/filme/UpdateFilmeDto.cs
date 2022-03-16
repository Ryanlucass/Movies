using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int Avaliacao { get; set; }
        public int ClassificacaoEtaria { get; set; }
    }
}
