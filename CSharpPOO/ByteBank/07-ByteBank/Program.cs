using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(398,993849);
            Console.WriteLine("Conta Guilherme: "+conta.Numero);
            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

            ContaCorrente contaDaGabriela = new ContaCorrente(148, 325841);
            Console.WriteLine("Conta Gabriela: "+contaDaGabriela.Numero);

            Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

            Console.ReadLine();

        }
    }
}
