using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exerc01.Classes
{
    class Boleto
    {
        public string Cedente { get; set; }
        public string Descricao { get; set; }
        public double ValorInicial { get; private set; }
        public DateTime DtEmissao { get; private set; }
        public DateTime DtVencimento { get; set; }
        public DateTime DtPagamento { get; private set; }

        private readonly double ValorMultaAts = 100.0;
        private readonly double TxJurosAd = 0.01;

        public Boleto(string cedente, string descricao,
            double valorInicial)
        {
            Cedente = cedente;
            Descricao = descricao;
            ValorInicial = valorInicial;
            DtEmissao = DateTime.Now.Date;
            DtVencimento = DtEmissao.AddDays(7);
        }

        public double Calcular(DateTime dtPagamento)
        {
            DtPagamento = dtPagamento;
            double ValorPagFinal = ValorInicial;

            if (DtPagamento > DtVencimento)
            {
                TimeSpan DiasAtraso = DtPagamento - DtVencimento;
                // Formula juros compostos Montante = Capital * ( 1 + i)^n
                double JurosCompostos = ValorPagFinal * Math.Pow((1 + TxJurosAd), DiasAtraso.Days); 
                ValorPagFinal = JurosCompostos + ValorMultaAts;
            }

            return ValorPagFinal;
        }
    }
}
