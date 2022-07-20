using System.Collections.Generic;
using RestricoesDeGenericosExemplo.Entities;
using RestricoesDeGenericosExemplo.Services;
using System.Globalization;
using System;

namespace RestricoesDeGenericosExemplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.WriteLine("Enter N: ");
            int n = int.Parse(Console.ReadLine());


            //adicionando elementos na lista 
            for (int i = 0; i < n; i++)
            {
                string[] vect = Console.ReadLine().Split(',');
                string name = vect[0];
                double price = double.Parse(vect[1],CultureInfo.InvariantCulture);
                list.Add(new Product(name, price));

            }

            //instancia o calculation
            CalculationService calculationService = new CalculationService();

            Product max = calculationService.Max(list);

            Console.WriteLine("Max: ");
            Console.WriteLine(max);
        }
    }
}
/*
 * RESTRIÇÕES DE GENÉRICOS
 * pra se encontrar o maior numa coleção, não pode ser qualquer tipo
 * tem que ser um tipo que seja possivel comprar os elementos.
 * 
 * outras possibilidades de restrição:
 * 
 * posso colocar que esse tipo tem que ser :
 * STRUCT: where T: struct
 * classe: where T: class
 * unmanaged: where T: unmanaged
 * que tenha um construtor: where T: new()
 * qualquer outro tipo(ex.: comparable): where T:<base type name>
 * Um outro tipo genérico definido na classe: where T: U
 */
