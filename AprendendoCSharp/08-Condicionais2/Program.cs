using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_Condicionais2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 8 Condicionais 2");


            int idadeJoao = 16;
            int quantidadePessoas = 2;
            bool acompanhado = quantidadePessoas >= 2;

            if (idadeJoao >= 18 || acompanhado == true)
            {
                Console.WriteLine("Maior de idade ou acompanhado. Pode entrar");
            }
            else
            {
                Console.WriteLine("Menor de idade desacompanhado. Não pode entrar");
            }

            Console.WriteLine("Tecle enter para sair");
            Console.ReadLine();

        }
    }
}
