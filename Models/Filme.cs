﻿using FilmesAPI.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required (ErrorMessage = "O campo diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Genero { get; set; }
        [Range(1,600, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máximo 600 minútos")]
        public int Duracao { get; set; }
        public int Avaliacao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
