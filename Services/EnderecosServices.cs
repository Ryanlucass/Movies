using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Interfaces;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System;

namespace FilmesAPI.Services
{
    public class EnderecosServices : IEnderecoServices
    {

        private FilmeContext _context;
        private readonly DbSessions _db;

        public EnderecosServices(FilmeContext context, DbSessions connection)
        {
            _context = context;
            _db = connection;
        }

        /// <summary>
        /// Adicionando endereço (ef) 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public AddEnderecoDto AdicionaEndereco(AddEnderecoDto enderecoDto)
        {
            if (enderecoDto != null)
            {
                Endereco endereco = new()
                {
                    Logradouro = enderecoDto.Logradouro,
                    Bairoo = enderecoDto.Bairoo,
                    Numero = enderecoDto.Numero,
                };

                _context.Enderecos.Add(endereco);
                _context.SaveChanges();

                AddEnderecoDto returnDto = new()
                {
                    Id = endereco.Id,
                    Bairoo = endereco.Bairoo,
                    Logradouro = endereco.Logradouro,
                    Numero = endereco.Numero
                };

                var result = _context.Enderecos.Add(endereco).CurrentValues;

                if (result != null) { return returnDto; }
                else { return null; };
            }

            return null;
        }
        /// <summary>
        /// recuperando endereços (ef)
        /// </summary>
        /// <returns></returns>
        public List<Endereco> RecuperaEndereco()
        {
            List<Endereco> enderecos;

            return enderecos = _context.Enderecos.ToList();

        }
        /// <summary>
        /// recuperando endereços por id (ef)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReadEnderecoDto RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDto readenderecodto = new ReadEnderecoDto()
                {
                    Bairoo = endereco.Bairoo,
                    Logradouro = endereco.Logradouro,
                    Numero = endereco.Numero
                };

                return (readenderecodto);
            }
            return null;
        }
        /// <summary>
        /// Atualizando endereços (ef) and (dapper)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateEnderecoDto"></param>
        /// <returns></returns>
        public bool AtualizarEnderecco(int id, UpdateEnderecoDto updateEnderecoDto)
        {
            //entitiy

            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            
            string logradouro = updateEnderecoDto.Logradouro != null ? updateEnderecoDto.Logradouro : endereco.Logradouro; 
            string bairro = updateEnderecoDto.Bairoo != null ? updateEnderecoDto.Bairoo : endereco.Bairoo;
            string numero = updateEnderecoDto.Numero != null ? updateEnderecoDto.Numero : endereco.Numero;

            //dapper
            string sql = @"
                        UPDATE Enderecos
                        SET Logradouro = @logradouro,
	                        Bairoo = @bairro,
	                        Numero = @numero
                        WHERE Id = @id";

            var consulta = _db.Connection.Query(sql, new
            {
                logradouro,
                bairro,
                numero,
                id
            });

            if (consulta != null) { return true; } else { return false; }

        }
        /// <summary>
        /// Deletar endereços (ef)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletarEndereco(int id)
        {

            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null) { _context.Remove(endereco); _context.SaveChanges(); return true; }
            else { return false; }

        }

    }
}
