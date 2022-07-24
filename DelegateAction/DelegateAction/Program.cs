using System;
using DelegateAction.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace DelegateAction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            //aplicar a funcao UpdatePrice em todos os elementos da lista:
            list.ForEach(UpdatePrice);// tem que ser uma fun que receba um prod e que seja void
            foreach(Product p in list)
            {
                Console.WriteLine(p);
            }

            //outras versões:
            //criar um obj do tipo delegate action:
            Action<Product> act = UpdatePrice;
            list.ForEach(act);//act como arg
            foreach(Product p in list)
            {
                Console.WriteLine(p);
            }

            //expressão lambda:
            Action<Product> action = p => { p.Price += p.Price * 0.1; };// as {} indicam que a fun tem um corpo, mas é void
        
            list.ForEach(action);// action como arg
            foreach(Product p in list)
            {
                Console.WriteLine(p);
            }

            //colocando o lambd diretamente no argumento do ForEach:
            list.ForEach(p => { p.Price += p.Price * 0.1; });//inline
            foreach(Product p in list)
            {
                Console.WriteLine(p);
            }
        }

        //função que atualiza o prceo de um produto
        static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;

        }
    }

 
}
