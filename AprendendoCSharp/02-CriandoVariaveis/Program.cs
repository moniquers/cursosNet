using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CriandoVariaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Início");

            int idade;
            idade = 28 + 1;
            Console.WriteLine("Idade: " + idade);

            idade = 1 + 14 * 2;
            Console.WriteLine("Idade: " + idade);

            idade = 14 * (2 + 1);
            Console.WriteLine("Idade: " + idade);

            Console.WriteLine("Tecle enter");
            Console.ReadLine();
        }
    }
}
