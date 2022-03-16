using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Interfaces;
using Dapper;

namespace FilmesAPI.Services
{
    public class FilmesService : IFilmeRepository
    {
        private FilmeContext _context;
        private DbSessions _db;

        public FilmesService(FilmeContext context, DbSessions conecction)
        {
            _context = context;
            _db = conecction;
        }
        /// <summary>
        /// adicionando filmes via body (ef)
        /// </summary>
        /// <param name="filmeDto"></param>
        /// <returns></returns>
        public AddFilmeDto AdicionaFilme(AddFilmeDto filmeDto)
        {
            if(filmeDto != null)
            {
                Filme filme = new()
                {   
                    Titulo = filmeDto.Titulo,
                    Diretor = filmeDto.Diretor,
                    Genero = filmeDto.Genero,
                    Duracao = filmeDto.Duracao,
                    Avaliacao = filmeDto.Avaliacao,
                    ClassificacaoEtaria = filmeDto.ClassificacaoEtaria

                };

                _context.Filmes.Add(filme);
                _context.SaveChanges();

                AddFilmeDto returnDto = new AddFilmeDto()
                {
                    Id = filme.Id,
                    Titulo = filme.Titulo,
                    Diretor = filme.Diretor,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    Avaliacao = filme.Avaliacao,
                    ClassificacaoEtaria = filme.ClassificacaoEtaria
                };

                //Verificação se foi criado de verdade
                var result = _context.Filmes.Add(filme).CurrentValues;
                
                if(result != null){return returnDto; }
                else{ return null; }
            };
            
            return null;

        }
        /// <summary>
        /// recuperação de filmes em geral por classificação etaria (dapper)
        /// </summary>
        /// <param name="classificacaoEtaria"></param>
        /// <returns></returns>
        public List<Filme> RecuperaFilmes(int? classificacaoEtaria)
        {
            if(classificacaoEtaria == null)
            {
                var response = _db.Connection.Query<Filme>("SELECT * FROM filmes").ToList();
                return response;
            }
            
            var resultespecific = _db.Connection.Query<Filme>(@"SELECT * FROM Filmes WHERE
                                          ClassificacaoEtaria <= @classificacaoEtaria ",new { 
            classificacaoEtaria
            }).ToList();

            return resultespecific;
        }
        /// <summary>
        /// Recuperando filmes por id de identificaçao (dapper)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {

            var resultespecific = _db.Connection.QueryFirstOrDefault<Filme>(@"SELECT * FROM Filmes WHERE Id= @id ", new
            {
                id
            });

            if(resultespecific == null) { return null; }


            ReadFilmeDto readFilmeDto = new()
            {
                Id = resultespecific.Id,
                Titulo = resultespecific.Titulo,
                Diretor = resultespecific.Diretor,
                Genero = resultespecific.Genero,
                Duracao = resultespecific.Duracao,
                Avaliacao = resultespecific.Avaliacao,
                ClassificacaoEtaria = resultespecific.ClassificacaoEtaria

            };

            return readFilmeDto;
        }
        /// <summary>
        /// atualização do filme posto (ef)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateFilmeDto"></param>
        /// <returns></returns>
        public bool AtualizarFilme(int id, UpdateFilmeDto updateFilmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null) return false;

            filme.Titulo = updateFilmeDto.Titulo;
            filme.Diretor = updateFilmeDto.Diretor;
            filme.Genero = updateFilmeDto.Genero;
            filme.Duracao = updateFilmeDto.Duracao;
            filme.Avaliacao = updateFilmeDto.Avaliacao;
            filme.ClassificacaoEtaria = updateFilmeDto.ClassificacaoEtaria;

            _context.SaveChanges();

            return true;
        }
        /// <summary>
        /// Deletar filme por id (ef)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletarFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
                                                                                                                                    
            if (filme == null) return false;
            else
            {
                _context.Remove(filme);
                _context.SaveChanges();
                return true;
            }  
        }
    }
}
