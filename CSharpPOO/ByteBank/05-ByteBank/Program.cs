using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cliente gabriela = new Cliente();
            //gabriela.nome = "Gabriela";
            //gabriela.profissao = "Desenvolvedora C#";
            //gabriela.CPF = "253.632.325-52";

            ContaCorrente conta = new ContaCorrente();

            if(conta.titular == null)
            {
                Console.WriteLine("Erro, referência para o objeto é NULL");
            }
            //conta.titular = gabriela;
            conta.saldo = 5000;
            conta.agencia = 454;
            conta.numero = 4154515;

            //conta.titular.nome = "Gabriela Costa";

            //Console.WriteLine(gabriela.nome);
            //Console.WriteLine(conta.titular.nome);
            Console.ReadLine();

        }
    }
}
