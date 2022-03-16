using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Interfaces
{
    public interface IGerenteServices
    {
        public AddGerenteDto AdicionaGerente(AddGerenteDto gerenteDto);
        public List<Gerente> RecupeGerente ();
        public Gerente RecupeGerentePorId(int id);
        public bool DeletarGerente(int id);
    }
}

