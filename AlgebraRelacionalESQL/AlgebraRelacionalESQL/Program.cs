using System;
using System.Linq;
using System.Collections.Generic;
using AlgebraRelacionalESQL.Entities;

namespace AlgebraRelacionalESQL
{
    internal class Program
    {//função auxiliar p imprimir os resultados dos testes:
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
            // var resultado1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);

            //sintaxe alternativa(similar ao sql):
            var r1 =
                 from p in products//td obj p na fonte de dados producs
                 where p.Category.Tier == 1 && p.Price < 900.0//restrição
                 select p;//projeção
            print("Tier 1 and price < 900.00:", r1);


            //Mostrar nomes dos produtos da categoria tools:
            // var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);//select esta pegando só o nome
            //sintaxe alternativa(similar ao sql):

            var r2 =
                from p in products
                where p.Category.Name == "Tools"//restrição
                select p.Name;//projeção

            print("Name of products from tools: ", r2);

            //mostrar produtos começados pela letra c com nome, preco e categoria. p isso crio o obj anonimo(p => new {...})
            /*crio um apelido pro nome da categoria(como o alias em sql): CategoryName = p.Category.Name,
             * crio esse apelido se eu colocar  p.category.name o compilador reclama pq tem 2 campos com o msm nome
             * */
            // var resultado3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });

            //sintaxe alternativa(similar ao sql):
            var r3 =
                from p in products
                where p.Name[0] == 'C'
                select new
                {
                    p.Name,
                    p.Price,
                    categoryName = p.Category.Name
        };
            print("NAMES STARTED WHIT C AND ANONYMOUS OBJECT: ", r3);

            //mostrar produtos com o TIER da categoria = 1 ordenado por preço:
            //OrderBy(p => p.Price).ThenBy(p => p.Name): ordena por preço, caso empate, ordena por nome.
            // var result4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            //sintaxe alternativa(similar ao sql):
            var r4 =
                from p in products
                where p.Category.Tier == 1
                orderby p.Name
                orderby p.Price
                select p;

            print("TIER 1 ORDER BY PRICE THEN BY NAME:", r4);

            //usar skip(pular) e take(pegar), muito usados em paginações:
            //var r5 = r4.Skip(2).Take(4);// pula os dois primeiros elementos e pega  4 elementos
            //sintaxe alternativa(similar ao sql):
            var r5 =
                (from p in r4
                 select p)//faz a expressão entre parenteses depois coloca a ultima operação que eu preciso
                 .Skip(2)
                 .Take(4);

            print("TIER 1 ORDER BY PRICE THEN BY NAME SKYPE 2 TAKE 4", r5);



            /*operação de agrupamento:
             *tipo de retorno de groupby:
             *coleção(Ienumerable, igrouping<category, product> par chave(category), coleção(product))
             */
            //var r16 = products.GroupBy(p => p.Category);
            //sintaxe alternativa(similar ao sql):
            var r16 =
                from p in products
                group p by p.Category;

            foreach (IGrouping<Category, Product> group in r16)//perc cada elem de r16 e cada ele é do tipo:<Category(chave), Product(colecao)>
            {
                Console.WriteLine("Category " + group.Key.Name + ":");//nome da categoria
                foreach (Product p in group)
                {
                    Console.WriteLine(p);//produtos
                }
                Console.WriteLine();
            }


        }
    }
}
