using System;
using System.Collections.Generic;

namespace ProgFuncCalcLambda
{
    internal class Program
    {
        public static int globalValue = 3;
        static void Main(string[] args)
        {
            int[] vect = new int[] { 3, 4, 5 };
            ChangeOddValues(vect);
            Console.WriteLine(String.Join(" ", vect));//o join pega cada elemento do vetor e juntar numa string só.
        }

        //altera os valores impares do vetor:
        public static void ChangeOddValues(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 2 != 0)
                {
                    numbers[i] += globalValue;// fora da funçãolinha(8)
                }
            }
        }
    }
}
