using System.Collections.Generic;
using System;

namespace RestricoesDeGenericosExemplo.Services
{
    internal class CalculationService
    {

        //método genérico:
        public T Max<T>(List<T> list) where T : IComparable// desde que T seja Icomparable(compareTo)
        {
            if (list.Count == 0)//se n tiver nada na lista
            {
                throw new ArgumentException("The list can not to be empty");
            }
            T max = list[0];
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo (max) > 0)//comparação usando o .CompareTo
                {
                    max = list[i];
                }
            }
            return max;
        }
    }
}
