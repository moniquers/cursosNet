using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacoDeRepeticaoFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto Tabuada");

            for (int linha = 1; linha <= 10; linha++)
            {
                for (int coluna = 1; coluna <= 10; coluna++)
                {
                    Console.WriteLine(linha + " x " + coluna + " = " + linha * coluna);
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
