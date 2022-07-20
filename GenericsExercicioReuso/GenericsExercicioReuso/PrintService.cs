using System;
using System.Collections.Generic;
using System.Text;


namespace GenericsExercicioReuso
{
    /*toda a classe PrintService é de um tipo generico específico do tipo T.
     * que pode ser qualquer outra letra,
     * o importante é manter um padrão.
     */
    internal class PrintService<T> //parametrizado com o tipo T
    {
        //vetor p armazenar 10 numeros inteiros:
        private T[] _values = new T[10];

        //contar quantos numeros foram add
        private int _count = 0;

        public void addValue(T value)
        {

            if (_count == 10)//programação de defesa
            {
                throw new InvalidOperationException("PrintService is full!");
            }
            _values[_count] = value;//_value na posiçao count = value
            _count++;

        }
        public T first()
        {
            if (_count == 0)//programação de defesa
            {
                throw new InvalidOperationException("PrintService is empty!");
            }

            return _values[0];
        }

        public void Print()
        {
            Console.Write("[");
            for (int i = 0; i < _count - 1; i++)//impriminto até a penultima posição do vetor
            {
                Console.Write(_values[i] + ", ");
            }

            if (_count > 0)
            {
                Console.Write(_values[_count - 1]);
            }
            Console.WriteLine("]");
        }
    }
}
