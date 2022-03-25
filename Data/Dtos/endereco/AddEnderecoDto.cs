using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class AddEnderecoDto
    {
        [Required]
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairoo { get; set; }
        public string Numero { get; set; }

        [Required]
        public string Cep { get; set; }
    }
}
