using System;
using System.Collections.Generic;
using ExcLInqLambdaSQL.Entities;
using System.IO;
using System.Linq;
using System.Globalization;
namespace ExcLInqLambdaSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Console.Write("Enter full file path");
             string path = Console.ReadLine();

             //instanciar a lista de prods
             List<Product> list = new List<Product>();

             //ler o arquivo do path instanciando novos produtos e inserindo na lista:

             using (StreamReader sr = File.OpenText(path))
             {
                 while (!sr.EndOfStream)
                 {
                     string[] fields = sr.ReadLine().Split(',');
                     string name = fields[0];
                     double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                     list.Add(new Product(name, price));
                 }
             }
             //encontrar o preço médio dos produtos:
             //1- transformar a lista de produtos em uma lista de preços(double)
             var avarage = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();//DefaultIfEmpty(0.0): evitar o prog quebrar, caso lista vazia
             Console.WriteLine("Avarage price = " + avarage.ToString("F2",CultureInfo.InvariantCulture));

             //mostrar nomes dos prod abaixo da média ordenados em ordem alfab decresente
             var names = list.Where(p => p.Price < avarage).OrderByDescending(p => p.Name).Select(p => p.Name);

             //mostrar p resultado:
             foreach(string name in names)
             {
                 Console.WriteLine(name);
             }
            */
            Console.WriteLine("enter full file path");
            string path = Console.ReadLine();

            using(StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                }
            }

            var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);

        }
    }
}
