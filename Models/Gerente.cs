using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Cinema> CinemasList { get; set; }
    }   
}
