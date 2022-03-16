using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Interfaces
{
    public interface IFilmeRepository
    {
        public AddFilmeDto AdicionaFilme(AddFilmeDto filmeDto);
        public List<Filme> RecuperaFilmes(int? classificacaoEtaria);
        public ReadFilmeDto RecuperaFilmesPorId(int id);
        public bool AtualizarFilme(int id, UpdateFilmeDto updateFilmeDto);
        public bool DeletarFilme(int id);

    }
}

