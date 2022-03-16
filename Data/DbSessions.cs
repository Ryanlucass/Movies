using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace FilmesAPI.Data
{
    public class DbSessions : IDisposable
    {
        public IDbConnection Connection { get; }
        
        public DbSessions(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration
                .GetConnectionString("Padrao"));

            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();

    }
}
