using System;
using MulticastDelegates.Services;

namespace MulticastDelegates
{
    //declaração do delegate:
    delegate void BinaryNumericOperation(double n1, double ne2);
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            //delegate guarda a referencia p duas funções: showsum e showmax
            BinaryNumericOperation op = CalculationService.showSum;
            op += CalculationService.ShowMax;

            //op.Invoke(a, b);
            //sintaxe alternativa:
            op.Invoke(a, b);


        }
    }
}
