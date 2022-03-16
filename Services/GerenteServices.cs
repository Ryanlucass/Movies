using Dapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Interfaces;
using FilmesAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Services
{
    public class GerenteServices : IGerenteServices
    {
        private FilmeContext _context;
        private readonly DbSessions _db;

        public GerenteServices(FilmeContext context, DbSessions connection)
        {
            _context = context;
            _db = connection;
        }

        /// <summary>
        /// Adicionando gerente (ef)
        /// </summary>
        /// <param name="gerenteDto"></param>
        /// <returns></returns>
        public AddGerenteDto AdicionaGerente(AddGerenteDto gerenteDto)
        {
            if (gerenteDto != null)
            {
                Gerente gerente = new Gerente() { Nome = gerenteDto.Nome };

                _context.Add(gerente);
                _context.SaveChanges();

                AddGerenteDto resulDto = new AddGerenteDto()
                {
                    Id = gerente.Id,
                    Nome = gerente.Nome
                };

                var result = _context.Gerentes.Add(gerente).CurrentValues;

                if (result != null) { return resulDto; }
                else { return null; }
            }

            return null;
        }

        /// <summary>
        /// Recuperando Gerentes (dapper)
        /// </summary>
        /// <returns></returns>
        public List<Gerente> RecupeGerente()
        {
            //dapper

            var sql = "SELECT * FROM Gerentes";
            
            var listagerentes = _db.Connection.Query<Gerente>(sql).ToList();

            return listagerentes != null ? listagerentes : null;

        }
        /// <summary>
        /// Recuperando gerentes por id (dapper)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Gerente RecupeGerentePorId(int id)
        {
            //entitiy

            //Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            //if (gerente != null)
            //{
            //    ReadGerenteDto readGerenteDto = new ReadGerenteDto()
            //    {
            //        Id = gerente.Id,
            //        Nome = gerente.Nome,
            //        Cinemas = gerente.CinemasList
            //    };

            //    return readGerenteDto;
            //}

            //return null;

            //dapper
            //dapper

            var sql = "SELECT * FROM Gerentes WHERE id = @id ";

            var gerente = _db.Connection.QueryFirstOrDefault<Gerente>(sql, new
            {
                id
            });

            return gerente != null ? gerente : null;

        }
        /// <summary>
        /// deletando gerente int (ef)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletarGerente(int id)
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

            if (gerente != null)
            {
                _context.Remove(gerente);
                _context.SaveChanges();

                return true;
            }

            return false;

        }

    }
}
