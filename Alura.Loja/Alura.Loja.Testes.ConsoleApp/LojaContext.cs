using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    internal class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder
                .Entity<PromocaoProduto>()
                //Primary Key Composta
                .HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder
                //shadow property
                .Entity<Endereco>()
                .Property<int>("ClienteId");
            modelBuilder
                .Entity<Endereco>()
                .HasKey("ClienteId");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
        }
    }
}