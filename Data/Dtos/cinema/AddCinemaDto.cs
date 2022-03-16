using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class AddCinemaDto
    {
        public int Id { get;  set; }
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
        public Gerente Gerente { get; set; }
        public Endereco Endereco { get; set; }
    }
    public class CinemadtoDapper
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
        public string Logradouro { get; set; }
        public string Bairoo { get; set; }
        public string Numero { get; set; }
        public string NomeGerente { get; set; }
    }
}