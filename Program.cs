using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace FilmesAPI
{
    public class Program
    {
        ////string de conexão
        //public static string Connectionstring => ConfigurationManager.AppSettings["Padrao"];

        //protected SqlConnection _connection;
        //protected SqlConnection connection => _connection ?? (_connection = GetOpenConnection());

        //public static SqlConnection GetOpenConnection()
        //{
        //    var cs = Connectionstring;

        //    var connection = new SqlConnection(cs);
        //    connection.Open();
        //    return connection;
        //}
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
