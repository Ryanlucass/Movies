using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Collections.Generic;

namespace FilmesAPI.Interfaces
{
    public interface IEnderecoServices
    {
        public AddEnderecoDto AdicionaEndereco(AddEnderecoDto enderecoDto);
        public List<Endereco> RecuperaEndereco();
        public ReadEnderecoDto RecuperaEnderecoPorId(int id);
        public bool AtualizarEnderecco(int id, UpdateEnderecoDto updateEnderecoDto);
        public bool DeletarEndereco(int id);
    }
}

