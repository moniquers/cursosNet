//using _07_ByteBank;

namespace _07_ByteBank
{
    public class ContaCorrente
    {

        public Cliente Titular { get; set; }
        public int Agencia { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        private int _numero;
        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                _numero = value;
            }
        }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        //Construtor
        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (this._saldo < valor)
            {
                return false;
            }
            this._saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (this._saldo < valor)
            {
                return false;
            }

            this._saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }

}
