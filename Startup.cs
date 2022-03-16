using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FilmesAPI.Data;
using FilmesAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FilmesAPI.Interfaces;

namespace FilmesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FilmeContext>(db => db.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("Padrao")));
    
            ///Entity
            services.AddScoped<FilmesService, FilmesService>();
            services.AddScoped<EnderecosServices, EnderecosServices>();
            services.AddScoped<CinemaServices, CinemaServices>();
            services.AddScoped<GerenteServices, GerenteServices>();
            services.AddScoped<SessaoServices, SessaoServices>();

            //Dapper
            services.AddScoped<DbSessions>();
            services.AddScoped<IFilmeRepository, FilmesService>();
            services.AddScoped<ICinemaRepository, CinemaServices>();
            services.AddScoped<ISessaoRepository, SessaoServices>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmesAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
