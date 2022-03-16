using Dapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Interfaces;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class CinemaServices : ICinemaRepository
    {
        private FilmeContext _context;
        private DbSessions _db;

        public CinemaServices(FilmeContext context, DbSessions connection)
        {
            _context = context;
            _db = connection;
        }

        /// <summary>
        /// Adicionando cinemas (ef)
        /// </summary>
        /// <param name="addcinemaDto"></param>
        /// <returns></returns>
        public AddCinemaDto AdicionaCinema(AddCinemaDto addcinemaDto)
        {
            if (addcinemaDto != null)
            {
                Cinema cinema = new()
                {
                    Nome = addcinemaDto.Nome,
                    EnderecoId = addcinemaDto.EnderecoId,
                    GerenteId = addcinemaDto.GerenteId,
                };

                _context.Cinemas.Add(cinema);
                _context.SaveChanges();

                AddCinemaDto returnDto = new()
                {
                  Id = cinema.Id,
                  Nome = cinema.Nome,
                  EnderecoId = cinema.EnderecoId,
                  Endereco = cinema.Endereco,
                  GerenteId = cinema.GerenteId,
                  Gerente = cinema.Gerente
                };

                //Verificação se foi criado de verdade
                var result = _context.Cinemas.Add(cinema).CurrentValues;
                
                if (result != null) { return returnDto; }
                else { return null; }

 

                //teste de retorno de lista e não de propriedade por ter relacionamentos 
            }

            return null;
        }
        /// <summary>
        /// Recuperando cinemas (dapper)
        /// </summary>
        /// <param name="nomefilme"></param>
        /// <returns></returns>
        public List<CinemadtoDapper> RecuperarCinema(string nomefilme)
        {
                  var sql = @"SELECT c.Id,
		                           C.Nome,
		                           C.EnderecoId,
		                           E.Logradouro,
		                           E.Bairoo,
		                           E.Numero, 
		                           C.GerenteId,
		                           G.Nome AS NomeGerente
	                          FROM Cinemas c
	                          INNER JOIN Enderecos E
	                          ON c.EnderecoId = E.Id
	                          INNER JOIN Gerentes G
	                          ON c.GerenteId = G.Id";

                var response = _db.Connection.Query<CinemadtoDapper>(sql).ToList();
                return response;
        }

        /// <summary>
        /// Recuperando cinemas por id (ef)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReadCinemaDto RecuperarCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema != null)
            {
                ReadCinemaDto readcinemadto = new ReadCinemaDto()
                {
                    Id = cinema.Id,
                    Nome = cinema.Nome,
                    Gerente = cinema.Gerente,
                    Endereco = cinema.Endereco
                };

                return readcinemadto;
            }
            else { return null; }
        }
        /// <summary>
        /// deletando cinema (ef)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
            
            if (cinema != null)
            {
                _context.Remove(cinema);

                _context.SaveChanges();

                return true;
            }
            else { return false; }

        }

    }
}
