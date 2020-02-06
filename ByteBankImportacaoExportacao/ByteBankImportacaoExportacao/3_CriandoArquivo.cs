using ByteBankImportacaoExportacao.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ByteBankImportacaoExportacao
{
    partial class Program
    {

        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "456,78945,6325.22,Gustavo Santos";

                var encoding = Encoding.UTF8;
                var bytes = encoding.GetBytes(contaComoString);

                fluxoDoArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDoArquivo))
            {
                escritor.Write("556,22945,8825.22,Pedro Silva");
            }
        }

        static void TestaEscrita()
        {
            var caminhoArquivo = "teste.txt";

            using(var fluxoDeArquivo = new FileStream(caminhoArquivo,FileMode.Create))
            using(var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 100000; i++)
                {
                    escritor.WriteLine($"Linha {i}");

                    escritor.Flush();

                    Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter para adicionar mais uma.");
                    Console.ReadLine();
                }
            }

        }
    }

}

