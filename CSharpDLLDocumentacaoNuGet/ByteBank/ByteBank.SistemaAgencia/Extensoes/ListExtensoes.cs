using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }

        /// <summary>
        /// Método utilizado para listar valores de um array
        /// </summary>
        /// <param name="itens">Array com os valores que serão listados</param>
        /// <param name="nomeCampo">Identificar elemento em cada posição da lista</param>
        public static void TestaForeach<T>(this IEnumerable<T> itens,string nomeCampo)
        {
            foreach (var item in itens)
            {
                Console.WriteLine($"{nomeCampo} no índice {itens.ToList().IndexOf(item)}: {item}");
            }
            Console.WriteLine();
        }

    }
}
