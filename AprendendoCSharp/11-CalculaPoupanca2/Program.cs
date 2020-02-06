using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_CalculaPoupanca2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 11 Poupança");

            double valorInvestido = 1000;

            Console.WriteLine("...");
            for (int contadorMes = 1; contadorMes <= 12; contadorMes++)
            {
                //valorInvestido = valorInvestido + valorInvestido * 0.0036;
                //valorInvestido += valorInvestido * 0.0036;
                valorInvestido *= 1.0036;
                Console.WriteLine("Após " + contadorMes + " mês você terá " + valorInvestido);
            }

            Console.WriteLine("Tecle enter para sair");
            Console.ReadLine();
        }
    }
}
