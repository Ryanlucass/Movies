using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }

        public FilmeContext(DbContextOptions<FilmeContext> db) : base(db)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            //Criando relacionamento entre endereço e cinema 1 para 1 

            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema) //hasone: existe relacionamento
                .WithOne(cinema => cinema.Endereco) //WithOne: onde um cinema tem 1 endereço
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId); // falando a chave estrangeira que liga entre eles 

            //Criando relacionamento entre gerente para clientes 1 para muitos

            builder.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.CinemasList)
                .HasForeignKey(cinema => cinema.GerenteId);

            //Relacionamento de N para N, criando uma tabela de intersessão
            //no caso Sessão 

            builder.Entity<Sessao>()
                .HasOne(Sessao => Sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(Sessao => Sessao.FilmeId);

            builder.Entity<Sessao>()
                .HasOne(Sessao => Sessao.Cinema)
    .           WithMany(cinema => cinema.Sessoes)
    .           HasForeignKey(Sessao => Sessao.CinemaId);
        }

    }
}
