using exerc01.Classes;
using System;

namespace exerc01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Cedente: ");
            string cedenteBlt = Console.ReadLine();
            Console.Write("Descrição do serviço: ");
            string descBlt = Console.ReadLine();
            Console.Write("Valor do serviço: R$");
            double valorBlt = double.Parse(Console.ReadLine());

            Boleto blt = new(
                cedenteBlt,
                descBlt,
                valorBlt
            );

            Console.WriteLine($"Data de Emissão: {blt.DtEmissao:dd/MM/yyyy}");
            Console.WriteLine($"Data de Vencimento: {blt.DtVencimento:dd/MM/yyyy}");

            Console.Write("Digite a data do pagamento: ");
            DateTime dtPagBlt = DateTime.Parse(Console.ReadLine());

            double valorFinalBlt = blt.Calcular(dtPagBlt);
            TimeSpan diasAtraso = blt.DtPagamento - blt.DtVencimento;

            Console.WriteLine($"Valor a pagar: {valorFinalBlt:C2}");
            Console.WriteLine($"O boleto foi pago com {diasAtraso.Days} dias de atraso");
           
        }
    }
}
