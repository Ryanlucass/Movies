using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Interfaces
{
    public interface ISessaoRepository
    {
        public CreateSessaoDto AdicionaSessao(CreateSessaoDto createsessaoDto);
        public List<Sessao> RecuperaSessao();
        public CreateSessaoDto RecuperaSessaoPorId(int id);
        public bool DeletarSessao(int id);
    }
}

