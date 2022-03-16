using Dapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Interfaces;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class SessaoServices : ISessaoRepository
    {
        public FilmeContext _context { get; set; }
        private readonly DbSessions _db;

        public SessaoServices(FilmeContext context, DbSessions connection)
        {
            _context = context;
            _db = connection;
        }
        /// <summary>
        /// Adicionando sessões (dapper)
        /// </summary>
        /// <param name="createsessaoDto"></param>
        /// <returns></returns>
        public CreateSessaoDto AdicionaSessao(CreateSessaoDto createsessaoDto)
        {
            var sqlinsert = @"INSERT INTO ESTUDO.dbo.Sessoes (
	                    FilmeId,
	                    CinemaId,
	                    HorarioDeEncerramento
	                    )

	                    OUTPUT
	                    INSERTED.FilmeId					AS FilmeId,
	                    INSERTED.CinemaId					AS CinemaId,
	                    INSERTED.HorarioDeEncerramento		AS HorarioInicio

	                    VALUES
	                    (
	                    @FilmeId,
	                    @CinemaId,
	                    @HorarioDeEncerramento
	                    )";

            //var sqlget = ""

            var response = _db.Connection.QueryFirstOrDefault<CreateSessaoDto>(sqlinsert, new
            {
                createsessaoDto.FilmeId,
                createsessaoDto.CinemaId,
                createsessaoDto.HorarioDeEncerramento
            });

            if(response != null) {return response; } else { return null; }
            
        }
        /// <summary>
        /// recuperando sessões (ef)
        /// </summary>
        /// <returns></returns>
        public List<Sessao> RecuperaSessao()
        {

            if (_context.Sessoes != null)
            {
                List<Sessao> sessoes;
                sessoes = _context.Sessoes.ToList();

                return sessoes;
            }

            return null;
        }
        /// <summary>
        /// recuperando sessão (ef)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CreateSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao != null)
            {
                CreateSessaoDto createsessaoDto = new CreateSessaoDto()
                {
                    Id = sessao.Id,
                    Cinema = sessao.Cinema,
                    Filme = sessao.Filme,
                    CinemaId = sessao.CinemaId,
                    FilmeId = sessao.FilmeId
                };

                return createsessaoDto;
            }

            return null;
        }
        /// <summary>
        /// Deletando sessões 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletarSessao(int id)
        {
            Sessao sessao = _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

            if (sessao != null)
            {
                _context.Remove(sessao);

                _context.SaveChanges();

                return true;
            }
            else { return false; }
        }
    }
}
