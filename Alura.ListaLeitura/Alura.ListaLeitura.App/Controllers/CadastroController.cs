using Alura.ListaLeitura.App.Models;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Alura.ListaLeitura.App.Controllers
{
    public class CadastroController: Controller
    {
        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);
            return "O livro foi adicionado com sucesso";
        }

        public IActionResult ExibeFormulario()
        {
            return View("formulario");
        }
 
    }
}
