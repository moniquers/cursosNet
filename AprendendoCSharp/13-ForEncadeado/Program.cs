using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_ForEncadeado
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 13 For Encadeado (break)");

            for (int contadorLinha = 1; contadorLinha < 10; contadorLinha++)
            {
                //for (int contadorColuna = 1; contadorColuna <= contadorLinha; contadorColuna++)
                //{
                // Console.Write("*");
                //}

                for (int contadorColuna = 1; contadorColuna <= 10; contadorColuna++)
                {
                    Console.Write("*");
                    if (contadorColuna >= contadorLinha)
                        break;
                }

                Console.WriteLine();
            }

            for (int linha = 0; linha < 5; linha++)
            {
                for (int coluna = 0; coluna < 5; coluna++)
                {
                    if (coluna > linha)
                    {
                        break;
                    }
                    Console.Write(coluna + 1);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Tecle enter para sair");
            Console.ReadLine();
        }
    }
}
