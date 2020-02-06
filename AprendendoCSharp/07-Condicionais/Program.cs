using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Condicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 7 Condicionais");


            int idadeJoao = 16;
            int quantidadePessoas = 2;

            if (idadeJoao >= 18)
            {
                Console.WriteLine("Maior de idade. Pode entrar");
            }
            else
            {
                if (quantidadePessoas >= 2)
                {
                    Console.WriteLine("Menor de idade acompanhado. Pode entrar");
                }
                else
                {
                    Console.WriteLine("Menor de idade desacompanhado. Não pode entrar");
                }
            }

            Console.WriteLine("Tecle enter para sair");
            Console.ReadLine();

        }
    }
}

