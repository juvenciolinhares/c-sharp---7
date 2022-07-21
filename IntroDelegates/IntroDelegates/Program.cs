using System;
using IntroDelegates.Services;

namespace IntroDelegates
{
    //declarar o delegate:
    delegate double BinaryNumericOperation(double n1, double n2);//referencia p uma função que rece e retorna 2 doubles
    internal class Program
    {
        static void Main(string[] args)
        {

            double a = 10;
            double b = 12;

            //declarar o objeto delegate que vai ser uma referencia p funcao CalculationService:

            //op faz ref p CalculationService.Sum
            BinaryNumericOperation opSum = CalculationService.Sum;

            double result = opSum(a, b);
            Console.WriteLine("Sum: " + result);

            //op faz ref p CalculationService.Max(sintaxe alternativa:)
            BinaryNumericOperation opMax = new BinaryNumericOperation(CalculationService.Max);//mais verboso
            result = opMax(a, b);
            Console.WriteLine("Sum: " + result);

            //n posso ter referencia op pra square pq op recebe 2 doubles e square apenas 1.

            //sintaxe alternativa 2:
            double c = 3;
            double d = 4;
            Console.Write("Sum com invoke: ");
            result = opSum.Invoke(c, d);
            Console.WriteLine(result);
        }
    }
}
