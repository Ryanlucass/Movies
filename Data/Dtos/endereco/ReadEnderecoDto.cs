using FilmesAPI.Models;
using System;

namespace FilmesAPI.Data.Dtos
{
    public class ReadEnderecoDto
    {
        public string Logradouro { get; set; }
        public string Bairoo { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
    }
}
