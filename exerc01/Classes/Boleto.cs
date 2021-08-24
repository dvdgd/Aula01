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
        public double Valor { get; set; }
        public double ValorMultaAts { get; set; }
        public double TaxaJurosAD { get; set; }
        public DateTime DtEmissao { get; set; }
        public DateTime DtVencimento { get; set; }
        public DateTime DtPagamento { get; set; }
        public double MultaPorAtraso{ get; set; }
        public Boleto()
        {

        }

        public Boleto(string cedente, string descricao, 
            double valor, double valorMultaAts, double taxaJurosAD, 
            DateTime dtPagamento, double multaPorAtraso)
        {
            Cedente = cedente;
            Descricao = descricao;
            Valor = valor;
            ValorMultaAts = valorMultaAts;
            MultaPorAtraso = multaPorAtraso;
            TaxaJurosAD = taxaJurosAD;
            DtEmissao = DateTime.Now.Date;
            DtVencimento = DtEmissao.AddDays(7); 
            DtPagamento = dtPagamento;
        }

        public double Calcular()
        {
            double ValorPagFinal = Valor;

            if ( DtPagamento > DtVencimento)
            {
                TimeSpan DiasAtraso = DtPagamento - DtVencimento;
                double ValorJuros = (Valor * TaxaJurosAD / 100) * DiasAtraso.Days;
                ValorPagFinal = ValorJuros + ValorPagFinal + 100;
            }
            
            return ValorPagFinal;
        }
    }
}
