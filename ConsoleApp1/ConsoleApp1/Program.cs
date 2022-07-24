using System;
using System.Collections.Generic;
using Predicate.Entities;
using System.Globalization;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.00));
            list.Add(new Product("HD Case", 80.90));

            //usando o predicate(produtos de 100.00+)
            //predicate é um func que recebe um obj e devolve um bool
            list.RemoveAll(productTest);//coloquei como parametro a fun auxiliar que eu criei depois do main.

            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }

            //sintaxe alternativa: usando lambda:
            //list.RemoveAll(p => p.price >= 100.00), em seguida faz o foreache p percorrer a lista atualizada.

        }

        //fun auxiliar que recebe um prod e devolve um bool
        public static bool productTest(Product p)
        {
            return p.Price >= 100.00;
        }
        /*predicate é um DELEGATE: uma referencia pra uma função
         * 
         */
    }
}
