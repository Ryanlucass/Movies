using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateCinemaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
