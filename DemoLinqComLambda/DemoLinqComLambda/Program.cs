using System;
using System.Linq;
using DemoLinqComLambda.Entities;
using System.Collections.Generic;

namespace DemoLinqComLambda
{
    internal class Program
    {

        //função auxiliar p imprimir os resultados dos testes:
        static void print<T>(string message, IEnumerable<T> collection)//IEnumerable p ficar compativel com linq
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //criar categorias:
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            //criar produtos(associando o prod à categoria descrita acima. ex: computador: c2: computer, etc.):
            List<Product> products = new List<Product>()
            {
                new Product(){Id =1, Name = "Computer", Price = 1100.0, Category = c2},
                new Product(){Id =2, Name = "Hammer", Price = 90.0, Category = c1},
                new Product(){Id =3, Name = "TV", Price = 1700.0, Category = c3},
                new Product(){Id =4, Name = "Notebook", Price = 1300.0, Category = c2},
                new Product(){Id =5, Name = "Saw", Price = 80.0, Category = c1},
                new Product(){Id =6, Name = "Tablet", Price = 700.0, Category = c2},
                new Product(){Id =7, Name = "Camera", Price = 700.0, Category = c3},
                new Product(){Id =8, Name = "Printer", Price = 350.0, Category = c3},
                new Product(){Id =9, Name = "MacBook", Price = 1800.0, Category = c2},
                new Product(){Id =10, Name = "Sound Bar", Price = 700.0, Category = c3},
                new Product(){Id =11, Name = "Level", Price = 70.0, Category = c1},
            };

            /****TESTES****/

            //mostrar todos os produtos(Tier 1 and price < 900):
            var resultado1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            print("Tier 1 and price < 900.00:", resultado1);

            //Mostrar nomes dos produtos da categoria tools:
            var resultado2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);//select esta pegando só o nome
            print("Name of products from tools: ", resultado2);

            //mostrar produtos começados pela letra c com nome, preco e categoria. p isso crio o obj anonimo(p => new {...})
            /*crio um apelido pro nome da categoria(como o alias em sql): CategoryName = p.Category.Name,
             * crio esse apelido se eu colocar  p.category.name o compilador reclama pq tem 2 campos com o msm nome
             * */
            var resultado3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            print("NAMES STARTED WHIT C AND ANONYMOUS OBJECT: ", resultado3);

            //mostrar produtos com o TIER da categoria = 1 ordenado por preço:
            //OrderBy(p => p.Price).ThenBy(p => p.Name): ordena por preço, caso empate, ordena por nome.
            var result4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            print("TIER 1 ORDER BY PRICE THEN BY NAME:", result4);

            //usar skip(pular) e take(pegar), muito usados em paginações:
            var result5 = result4.Skip(2).Take(4);// pula os dois primeiros elementos e pega  4 elementos
            print("TIER 1 ORDER BY PRICE THEN BY NAME SKYPE 2 TAKE 4", result5);

            //operações que pegam os elementos:
            var result6 = products.First();
            Console.WriteLine("First test1: " + result6);

            var result7 = products.Where(p => p.Price > 3000.00).FirstOrDefault();//se nao encontrar ninguem, retorna nulo
            Console.WriteLine("First or default test2: " + result7);//fica em branco pq retorna nulo pq n econtrou ninguem

            /*
             * usando single e SingleOrDefault
             * SingleOrDefault: retorna o obj do tipo product
             * se eu uso apenas products.Where(p => p.Id == 3) vai retornar uma coleção e n o obj.
             * o single/SingleOrDefault retorna 1 ou nenhum ele. qualquer coisa diferente desse result vai quebrar i prog
             */
            var result8 = products.Where(p => p.Id == 3).SingleOrDefault();//uma busca por id retorna 1 ou nenhum elemento
            Console.WriteLine("single or default teste1: " + result8);

            //teste com SingleOrDefault p nao retornar elem.:
            var result9 = products.Where(p => p.Id == 30).SingleOrDefault();
            Console.WriteLine("single or default teste2: " + result9);//retorna null pq n tem id = 30

            //pegar o maximo da coleção:
            var result10 = products.Max(p => p.Price);//preço maior da coleção
            Console.WriteLine("Max Price: " + result10);

            //pegar o menor preço:
            var result11 = products.Min(p => p.Price);
            Console.WriteLine("Min Price: " + result11);

            //categoria 1, soma desses preços:
            var r12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("Category 1, Sum Prices: " + r12);

            //categoria 1, media desses preços:
            var r13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("Category 1, Avarage Prices: " + r13);

            //caso eu tente fazer uma média, mas nao tenha elem ou seja x/0(n existe), faço o seguinte:
            //Select(p => p.Price).DefaultIfEmpty().Average(): se o result for vazio, atribui o resul. 0
            var r14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty().Average();
            Console.WriteLine("Category 5, Avarage Prices: " + r14);

            /***OPERAÇÕES PERSONALIZADAS***/

            //até agora trabalhamos com op ja existentes: soma, sub, max, etc.
            //soma dos preços desse resultado(select aggregate):
            var r15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);//função anonima p soma
            Console.WriteLine("Category 1 aggregate sum: " + r15);

            //e se o resultado de p => p.Category.Id == 1 for vazio?
            var r151 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);//define um valor inicial = 0.0
            Console.WriteLine("Category 1 aggregate sum: " + r151);
            Console.WriteLine();

            /*operação de agrupamento:
             *tipo de retorno de groupby:
             *coleção(Ienumerable, igrouping<category, product> par chave(category), coleção(product))
             */
            var r16 = products.GroupBy(p => p.Category);
            foreach(IGrouping<Category, Product> group in r16)//perc cada elem de r16 e cada ele é do tipo:<Category(chave), Product(colecao)>
            {
                Console.WriteLine("Category " + group.Key.Name + ":");//nome da categoria
                foreach(Product p in group)
                {
                    Console.WriteLine(p);//produtos
                }
                Console.WriteLine();
            }
           

        }
    }
}
