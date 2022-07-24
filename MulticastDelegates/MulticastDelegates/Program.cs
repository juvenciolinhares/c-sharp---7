using System;
using MulticastDelegates.Services;

namespace MulticastDelegates
{
    //declaração do delegate como void:
    delegate void BinaryNumericOperation(double n1, double ne2);
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 10;
            double b = 12;

            //delegate guarda a referencia p duas funções: showsum e showmax
            BinaryNumericOperation op = CalculationService.showSum;
            op += CalculationService.ShowMax; //operador += atribui o showmax ao showsum

            //op.Invoke(a, b);
            op.Invoke(a, b);// printa showmax e showsum

            //sintaxe alternativa:
            op(a, b);


        }
    }
}
