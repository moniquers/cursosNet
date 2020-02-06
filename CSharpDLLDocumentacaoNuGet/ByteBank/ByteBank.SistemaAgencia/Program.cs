using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;

namespace ByteBank.SistemaAgencia
{
    class Program
    {

        static void Main(string[] args)
        {

            var btnCancelar = new Botao();
            btnCancelar.Cor = CoresBotao.Verde;
            btnCancelar.Texto = "Cancelar";
























            //TestaWhere();
            //TestaOrderByComLambda();
            //TestaIComparableEIComparer();
            //TestaSort();
            //TestaMetodoExtensaoGenerico();
            //TestaMetodoExtensao();
            //TestaList();
            //TestaListaDeObject();
            //TestaParams();
            //TestaEquals();
            //TestaToString();
            //TestaRegularExpressions();
            //TestaWithMethods();
            //TestaExtratorDeArgumentos();
            //TestaRemove();
            //TestaArrayInt();
            //TestaArrayDeContasCorrentes();
            return;
        }

        static void TestaWhere()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(156, 94456),
                new ContaCorrente(662, 11456),
                null,
                new ContaCorrente(356, 84456),
                null,
                new ContaCorrente(299, 99456),
            };

            //var contasOrdenadas = contas.Where(conta => conta != null);
            //contasOrdenadas = contasOrdenadas.OrderBy(conta => conta.Agencia);

            var contasOrdenadas = contas
                .Where(contas => contas != null)
                .OrderBy(conta => conta.Agencia);

            contasOrdenadas.TestaForeach("Conta");
        }

        static void TestaOrderByComLambda()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(156, 94456),
                new ContaCorrente(662, 11456),
                null,
                new ContaCorrente(356, 84456),
                new ContaCorrente(299, 99456),
                null
            };

            var contasOrdenadas = contas.OrderBy(
                conta =>
                {
                    if (conta == null)
                    {
                        return int.MinValue;
                    }
                    return conta.Agencia;
                }
            );

            contasOrdenadas.TestaForeach("Conta");


            var meses = new List<string>()
            { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };

            var mesesOrdenados = meses.OrderBy(mes => mes);

            mesesOrdenados.TestaForeach("Mês");
        }

        static void TestaIComparableEIComparer()
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(156, 94456),
                new ContaCorrente(662, 11456),
                new ContaCorrente(356, 84456),
                new ContaCorrente(299, 99456),
            };


            contas.Sort(); // Implementação de CompareTo() da interface IComparable (ContaCorrente)
            contas.TestaForeach("Conta");

            contas.Sort(new ComparadorContaCorrentePorAgencia()); // Implementação de Compare() da interface IComparer (ComparadorContaCorrentePorAgencia)
            contas.TestaForeach("Conta");
        }

        static void TestaSort()
        {
            var idades = new List<int>() { 26, 7, 12 };
            idades.Add(11);
            idades.AdicionarVarios(51, 2);

            idades.Sort();
            idades.TestaForeach(nomeCampo: "Idade");

            var nomes = new List<string>(){
                "Guilherme",
                "Evandro",
                "Monique",
                "Elber"
            };
            nomes.Sort();
            nomes.TestaForeach(nomeCampo: "Nome");

        }

        static void TestaMetodoExtensaoGenerico()
        {
            List<int> idades = new List<int>();
            idades.Add(7);
            idades.Add(12);
            idades.Add(26);

            //ListExtensoes.AdicionarVarios(idades, 33, 55, 44); =
            //idades.AdicionarVarios<int>(77, 88, 99); =
            idades.AdicionarVarios(77, 88, 99);
            idades.TestaForeach("Idade");

            List<string> nomes = new List<string>();
            nomes.Add("Guilherme");
            nomes.AdicionarVarios("Evandro", "Monique");
            nomes.TestaForeach("Nome");
        }

        static void TestaMetodoExtensao()
        {
            List<int> idades = new List<int>();

            idades.Add(7);
            idades.Add(12);
            idades.Add(26);

            idades.Remove(12);

            //Usando o "this" no argumento do método AdicionarVarios na class ListExtensoes
            idades.AdicionarVarios(77, 88, 99);

            int acumulador = 0;
            for (int i = 0; i < idades.Count; i++)
            {
                int idade = idades[i];
                acumulador += idade;
                Console.WriteLine($"Idade no índice {i}: {idade}");
            }
        }

        static void TestaList()
        {
            List<int> idades = new List<int>();

            idades.Add(7);
            idades.Add(12);
            idades.Add(26);

            idades.Remove(12);

            //Sem o "this" no argumento do método AdicionarVarios na class ListExtensoes
            ListExtensoes.AdicionarVarios(idades, 77, 88, 99);

            int acumulador = 0;
            for (int i = 0; i < idades.Count; i++)
            {
                int idade = idades[i];
                acumulador += idade;
                Console.WriteLine($"Idade no índice {i}: {idade}");
            }
            Console.WriteLine($"Média: {acumulador / idades.Count}");
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.AdicionarVarios(2, 6, 4);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade índice {i}: {idade}");
            }
        }

        static void TestaParams()
        {

            ContaCorrente contaDoGui = new ContaCorrente(999, 9999);
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoGui,
                new ContaCorrente(1111, 111111),
                new ContaCorrente(2222, 222222),
                new ContaCorrente(3333, 333333)
            };

            //Enviando array
            lista.AdicionarVarios(contas);

            //Enviando params
            lista.AdicionarVarios(contaDoGui,
                new ContaCorrente(5550, 9995),
                new ContaCorrente(5550, 9995),
                new ContaCorrente(5550, 9995),
                new ContaCorrente(5458, 7985));

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Conta {i}: {itemAtual.Agencia} - {itemAtual.Numero}");
            }

            Console.WriteLine($"Teste de uso de params (soma): {SomarVarios(2, 4, 6, 8)}");

            static int SomarVarios(params int[] numeros)
            {

                int acumulador = 0;
                foreach (int numero in numeros)
                {
                    acumulador += numero;
                }
                return acumulador;
            }

        }

        static void TestaEquals()
        {

            //Método reescrito na class ContaCorrente

            Cliente carlos1 = new Cliente();
            carlos1.Nome = "Carlos";
            carlos1.CPF = "45812625412";
            carlos1.Profissao = "Desenvolvedor";

            Cliente carlos2 = new Cliente();
            carlos2.Nome = "Carlos";
            carlos2.CPF = "45812625412";
            carlos2.Profissao = "Desenvolvedor";

            Console.WriteLine("Objetos iguais (Equals)? " + carlos1.Equals(carlos2));

            ContaCorrente conta2 = new ContaCorrente(985, 9955);
            Console.WriteLine("Objetos iguais (Equals)? " + carlos1.Equals(conta2));

            Console.WriteLine();
        }

        static void TestaToString()
        {
            object conta = new ContaCorrente(958, 5284);
            object desenvolvedor = new Desenvolvedor("9655");

            string contaToString = conta.ToString();

            Console.WriteLine("Resultado " + contaToString);
            Console.WriteLine(conta);
            Console.WriteLine();
        }

        static void TestaRegularExpressions()
        {
            // string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // string padrao = "[0-9]{4,5}[-][0-9]{4}";
            // string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoDeTeste = "Meu nome é Monique e meu telefone é 97965-42824";

            Match resultado = Regex.Match(textoDeTeste, padrao);
            Console.WriteLine(resultado.Value);

            string padraoCPF = "[0-9]{3}.?[0-9]{3}.?[0-9]{3}-?[0-9]{2}";
            string textoDeTesteCPF = "Meu CPF é 405.971.298-19";
            Match resultadoCPF = Regex.Match(textoDeTesteCPF, padraoCPF);
            Console.WriteLine(resultadoCPF.Value);
            Console.WriteLine();
        }

        static void TestaWithMethods()
        {
            string urlTeste = "https://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com/cambio");

            Console.WriteLine($"IndexOf = 0: {indiceByteBank == 0}");
            Console.WriteLine($"StartsWith: {urlTeste.StartsWith("https://www.bytebank.com/cambio")}");
            Console.WriteLine($"EndsWith: {urlTeste.EndsWith("cambio")}");
            Console.WriteLine($"Contains: {urlTeste.Contains("bytebank")}");
            Console.WriteLine();

        }

        static void TestaExtratorDeArgumentos()
        {
            string urlParametros = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(urlParametros);
            Console.WriteLine("Moeda origem: " + extratorDeValores.GetValor("moedaOrigem"));
            Console.WriteLine("Moeda destino: " + extratorDeValores.GetValor("moedaDestino"));
            Console.WriteLine("Moeda destino: " + extratorDeValores.GetValor("valor"));
            Console.WriteLine();
        }

        static void TestaRemove()
        {
            //Testando o método Remove
            string testeRemocao = "primeiraParte&parteParaRemover";
            Console.WriteLine(testeRemocao);

            int indiceEComercial = testeRemocao.IndexOf('&');
            Console.WriteLine(testeRemocao.Remove(indiceEComercial));
            Console.WriteLine();


            string palavra = "moedaOrigem=moedaDestino&moedaDestino=dolar";
            Console.WriteLine(palavra);

            string nomeArgumento = "moedaDestino=";

            int indice = palavra.IndexOf(nomeArgumento);
            Console.WriteLine($"String nomeArgumento: {nomeArgumento}, Tamanho da string: {nomeArgumento.Length}, Índice: {indice}");

            Console.WriteLine($"Substring à partir do índice {indice}: {palavra.Substring(indice)}");

            Console.WriteLine($"Substring à partir do índice + tamanho do nomeArgumento ({indice} + {nomeArgumento.Length}): {palavra.Substring(indice + nomeArgumento.Length)})");

            Console.WriteLine();
        }

        static void TestaArrayInt()
        {
            //int[] idades = new int[5];

            //idades[0] = 12;
            //idades[1] = 22;
            //idades[2] = 31;
            //idades[3] = 42;
            //idades[4] = 55;

            int[] idades = new int[] { 12, 22, 31, 42, 55 };

            int acumulador = 0;

            for (int i = 0; i < idades.Length; i++)
            {
                int idade = idades[i];
                Console.WriteLine($"Acessando o array idades no índice {i}");
                Console.WriteLine($"Valor de idades[{i}] = {idade}");
                acumulador += idade;
            }
            int media = acumulador / idades.Length;

            Console.WriteLine("Média: " + media);
            Console.WriteLine();
        }

        static void TestaArrayDeContasCorrentes()
        {
            //ContaCorrente[] contas = new ContaCorrente[3];

            //contas[0] = new ContaCorrente(123, 3214);
            //contas[1] = new ContaCorrente(195, 6954);
            //contas[2] = new ContaCorrente(111, 6251);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(123, 3214),
                new ContaCorrente(195, 6954),
                new ContaCorrente(111, 6251)
            };

            for (int i = 0; i < contas.Length; i++)
            {
                Console.WriteLine($"Agencia: {contas[i].Agencia}, Conta: {contas[i].Numero}, Saldo: {contas[i].Saldo}");
            }
            Console.WriteLine();
        }

        static int SomarVarios(params int[] itens)
        {
            int acumulador = 0;
            foreach (int item in itens)
            {
                acumulador += item;
            }
            return acumulador;

        }

    }
}
