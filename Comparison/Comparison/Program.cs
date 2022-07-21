using System;
using Comparison.Entities;
using System.Collections.Generic;


namespace Comparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //cirando uma lista e add produtos:
            List<Product> list = new List<Product>();
            list.Add(new Product("TV", 900.00));
            list.Add(new Product("Notebook", 1200.00));
            list.Add(new Product("Tablet", 450.00));

            //usei lambda diretamente no argumento do metodo sort.
            list.Sort((p1, p2)=> p1.Name.ToUpper().CompareTo(p2.Name.ToUpper()));

            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }

        }

    }
}
/*
 * Comparison<T>:
 * implementar a comparação por meio da interface IComparable<Product>
 * 
 * expressão LAMBDA: função anonima, não precisa ser declarada
 * 
 * 
 */
