using System;
using DelegateFunc.Entities;
using System.Collections.Generic;
using System.Linq;// importo pra conseguir acessar o select 

namespace DelegateFunc
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

            /**criar nova lista com nomes em caixa alta:**/

            //colocando o método NameUpper como referencia:
            List<string> result = list.Select(NameUpper).ToList();// converter pra lista
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }

            //colocando o func como referencia:
            Func<Product, string> func = NameUpper;
            List<string> resulcFunc = list.Select(func).ToList();
            foreach (string s in resulcFunc)
            {
                Console.WriteLine(s);
            }

            //versões com expressão lambda(nesse caso a função NameUpper vai ser substituida ):
            Func<Product, string> funcLambda = p => p.Name.ToUpper();
            List<string> resulcLambda = list.Select(funcLambda).ToList();
            foreach (string s in resulcLambda)
            {
                Console.WriteLine(s);
            }

            //expressão lambda inline: 
            List<string> resultLambdaInline = list.Select(p => p.Name.ToUpper()).ToList();
            foreach(string s in resultLambdaInline)
            {
                Console.WriteLine(s);
            }

        }

        static string NameUpper(Product p)
        {
            return p.Name.ToUpper();
        }
    }
}
/*gerar um nova lista contendo o nome dos produtos em caixa alta
 * pra fazer isso, uso a função SELECT
 * a funçáo select pega uma coleção e transforma em outra
*/