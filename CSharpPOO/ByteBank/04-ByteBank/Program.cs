using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaDoBruno = new ContaCorrente();

            Console.WriteLine("Saldo inicial Bruno: " + contaDoBruno.saldo);

            bool resultadoSaque = contaDoBruno.Sacar(500);
            Console.WriteLine("Saldo após o saque Bruno: " + contaDoBruno.saldo);
            Console.WriteLine("Resultado saque: " + resultadoSaque);

            contaDoBruno.Depositar(500);
            Console.WriteLine("Saldo após depósito Bruno: " + contaDoBruno.saldo);

            ContaCorrente contaDaGabriela = new ContaCorrente();
            contaDaGabriela.titular = "Gabriela";

            Console.WriteLine("Saldo inicial Gabriela: " + contaDaGabriela.saldo);

            contaDoBruno.Transferir(2000, contaDaGabriela);
            Console.WriteLine("Saldo após transferência Bruno: " + contaDoBruno.saldo);
            Console.WriteLine("Saldo após transferência Gabriela: " + contaDaGabriela.saldo);

            contaDaGabriela.Transferir(100, contaDoBruno);
            Console.WriteLine("Saldo após transferência Bruno: " + contaDoBruno.saldo);
            Console.WriteLine("Saldo após transferência Gabriela: " + contaDaGabriela.saldo);

            Console.ReadLine();
        }
    }
}
