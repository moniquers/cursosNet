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
        static void LidandoComFileStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; //1kb
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                    Console.WriteLine($"\nBytes lidos ************************************ {numeroDeBytesLidos}");
                }
            }
        }
        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding();
            var texto = utf8.GetString(buffer, 0, bytesLidos);

            Console.Write(texto);
        }
    }
}
