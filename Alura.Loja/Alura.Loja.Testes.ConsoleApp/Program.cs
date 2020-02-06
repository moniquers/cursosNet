using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {


            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}");

                var produto = contexto
                    .Produtos
                    .Where(p => p.Id == 3002)
                    .FirstOrDefault();

                //Substitui include para filtrar compras
                //Carregamento explícito
                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query()
                    .Where(c => c.Preco > 10)
                    .Load();


                Console.WriteLine($"Compras do produto: {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }

            }





            //IncluiCompras();
            //SelectJoinUmParaComInclude();
            //SelectJoinMuitosParaMuitos();
            //IncluiPromocao();
            //EFUmParaUm();
            //EFMuitosParaMuitos();
            //EFUmParaMuitos();
            //AtualizarProduto();
            //ExcluirProdutos();
            //RecuperarProdutos();
            //GravarUsandoEntity();
            //GravarUsandoAdoNet();
            Console.ReadLine();
        }

        private static void IncluiCompras()
        {
            using (var contexto = new LojaContext())
            {
                var produto = contexto.Produtos.Find(3002);

                var compra = new Compra();
                compra.Quantidade = 40;
                compra.Produto = produto;
                compra.Preco = produto.PrecoUnitario * compra.Quantidade;

                contexto.Compras.Add(compra);

                contexto.SaveChanges();
                Console.WriteLine($"Compra incluída: {compra.Quantidade} unidades de {produto.Nome} R$ {compra.Preco}");

            }
        }

        private static void SelectJoinUmParaUmComInclude()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}");

                var produto = contexto
                    .Produtos
                    .Include(p => p.Compras)
                    .Where(p => p.Id == 3003)
                    .FirstOrDefault();

                Console.WriteLine($"Compras do produto: {produto.Nome}");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine(item);
                }

            }
        }

        private static void SelectJoinMuitosParaMuitos()
        {
            using (var contexto2 = new LojaContext())
            {
                var serviceProvider = contexto2.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = contexto2
                    .Promocoes
                    //Join
                    .Include(p => p.Produtos)
                    .ThenInclude(pp => pp.Produto)
                    .FirstOrDefault();

                Console.WriteLine("\nMostrando os produtos da promoção...\n");

                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }

        private static void IncluiPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Janeiro 2017";
                promocao.DataInicio = new DateTime(2017, 1, 1);
                promocao.DataTermino = new DateTime(2017, 1, 31);

                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas")
                    .ToList();
                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.Promocoes.Add(promocao);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();
            }
        }

        private static void EFUmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Inválidos",
                Complemento = "sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }

        static void EFMuitosParaMuitos()
        {
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Pascoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            using (var contexto = new LojaContext())
            {

                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var promocao = contexto.Promocoes.Find(1);
                contexto.Promocoes.Remove(promocao);

                //contexto.Promocoes.Add(promocaoDePascoa);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.SaveChanges();

            }
        }

        static void EFUmParaMuitos()
        {
            var paoFrances = new Produto();
            paoFrances.Nome = "Pão francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {

                var serviceProvider = contexto.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Compras.Add(compra);

                ExibeEntries(contexto.ChangeTracker.Entries());

                //contexto.SaveChanges();

            }
        }

        //ChangeTracker
        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }
        //private static void AtualizarProduto()
        //{
        //    // inclui um produto
        //    GravarUsandoEntity();
        //    RecuperarProdutos();

        //    using (var repo = new ProdutoDAOEntity())
        //    {
        //        Produto produto = repo.Produtos().First();
        //        produto.Nome = "Pulp Fiction";
        //        repo.Atualizar(produto);
        //    }
        //    RecuperarProdutos();
        //}

        //private static void ExcluirProdutos()
        //{
        //   using(var repo = new ProdutoDAOEntity())
        //    {
        //        IList<Produto> produtos = repo.Produtos().ToList();
        //        foreach (var produto in produtos)
        //        {
        //            repo.Remover(produto);
        //        }
        //    }

        //}

        //private static void RecuperarProdutos()
        //{
        //    using(var repo = new ProdutoDAOEntity())
        //    {
        //        IList<Produto> produtos = repo.Produtos().ToList();

        //        Console.WriteLine($"Foram encontrados {produtos.Count}");

        //        foreach (var produto in produtos)
        //        {
        //            Console.WriteLine(produto.Nome);
        //        }
        //    }
        //}

        //private static void GravarUsandoEntity()
        //{
        //    Produto p = new Produto();
        //    p.Nome = "Harry Potter e a Pedra Filosofal";
        //    p.Categoria = "Livros";
        //    p.Preco = 19.89;

        //    using (var repo = new ProdutoDAOEntity())
        //    {
        //        repo.Adicionar(p);
        //    }
        //}

        //private static void GravarUsandoAdoNet()
        //{
        //    Produto p = new Produto();
        //    p.Nome = "Harry Potter e a Ordem da Fênix";
        //    p.Categoria = "Livros";
        //    p.Preco = 19.89;

        //    using (var repo = new ProdutoDAO())
        //    {
        //        repo.Adicionar(p);
        //    }
        //}

    }
}
