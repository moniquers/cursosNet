using Alura.ListaLeitura.App.Logica;
using Alura.ListaLeitura.App.Mvc;
using Microsoft.AspNetCore.Builder;
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

            routeBuilder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);

            //routeBuilder.MapRoute("Livros/ParaLer", LivrosLogica.ParaLer);
            //routeBuilder.MapRoute("Livros/Lidos", LivrosLogica.Lidos);
            //routeBuilder.MapRoute("Livros/Lendo", LivrosLogica.Lendo);
            //routeBuilder.MapRoute("Livros/Detalhes/{id:int}", LivrosLogica.Detalhes);
            //routeBuilder.MapRoute("Cadastro/NovoLivro/{titulo}/{autor}", CadastrosLogica.NovoLivro);
            //routeBuilder.MapRoute("Cadastro/ExibeFormulario", CadastrosLogica.ExibeFormulario);
            //routeBuilder.MapRoute("Cadastro/Incluir", CadastrosLogica.Incluir);
            var rotas = routeBuilder.Build();

            app.UseRouter(rotas);

        }  
    }
}
