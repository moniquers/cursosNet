using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {


        public void ConfigureServices(IServiceCollection service)
        {
            service.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapRoute("Livros/ParaLer", LivrosParaLer);
            routeBuilder.MapRoute("Livros/Lidos", LivrosLidos);
            routeBuilder.MapRoute("Livros/Lendo", LivrosLendo);
            routeBuilder.MapRoute("Cadastro/NovoLivro/{titulo}/{autor}", NovoLivroParaLer);
            routeBuilder.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes);
            routeBuilder.MapRoute("Cadastro/NovoLivro", ExibeFormulario);
            routeBuilder.MapRoute("Cadastro/Incluir", ProcessaFormulario);
            var rotas = routeBuilder.Build();

            app.UseRouter(rotas);

        }

        private Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Query["titulo"].First(),
                Autor = context.Request.Query["autor"].First()
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso");
        }

        private Task ExibeFormulario(HttpContext context)
        {
            var html = @"
            <html>
                <form action='/Cadastro/Incluir'>
                    <input name='titulo' />
                    <input name='autor' />
                    <button>Gravar</button>
                </form>
            </html>";
            return context.Response.WriteAsync(html);
        }

        private Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);

            return context.Response.WriteAsync(livro.Detalhes());

        }

        public Task NovoLivroParaLer(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = Convert.ToString(context.GetRouteValue("titulo")),
                Autor = Convert.ToString(context.GetRouteValue("autor")) 
            };

            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return context.Response.WriteAsync("O livro foi adicionado com sucesso");
        }

        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }
        public Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }
        public Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }
    }
}
