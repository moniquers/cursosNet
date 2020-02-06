using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_CriandoVariaveisPontoFlutuante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto 3 - Criando variáveis ponto flutuante");

            double salario;
            salario = 1230.45;
            Console.WriteLine("Salário: " + salario);

            double idade;
            idade = 27 / 2;
            Console.WriteLine("Idade 27 / 2: ......" + idade);

            idade = 27.0 / 2;
            Console.WriteLine("Idade 27.0 / 2: ...." + idade);


            Console.WriteLine("Tecle enter para sair");
            Console.ReadLine();
        }
    }
}
