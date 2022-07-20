using System;
using System.Collections.Generic;
using ComparacaoDeIgualdades.Entities;

namespace ComparacaoDeIgualdades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //verificação com gethashcode e equals implementados
            HashSet<string> set = new HashSet<string>();
            set.Add("Maria");
            set.Add("Alex");
            Console.WriteLine(set.Contains("Maria"));// acontece da seguinte forma: testa pelo gethashcode e confirma com o equals

            //verificação com gethashcode e equals NÃO implementados:

            HashSet<Product> a = new HashSet<Product>();

            //add um produto:
            a.Add(new Product("Tv", 900.0));
            a.Add(new Product("Notebook", 1200.0));

            //add um ponto
            HashSet<Point> b = new HashSet<Point>();
            b.Add(new Point(3, 4));
            b.Add(new Point(5, 10));


            /***tipo referencia:compara as referencias do obj***/

            Product prod = new Product("Notebook", 1200.0);
            //teste: em a existe o conjunto prod?
            Console.WriteLine(a.Contains(prod));//da falso pq os endereços de memória sao diferentes
            
            
            //tipo valor :compara pelo valor do atributo(conteúdo), então não precisa de implementação na "classe" struct
            Point p = new Point(5, 10);
            Console.WriteLine(b.Contains(p));
        }
    }
}
/*
 * se eu chamo o "new" em Product prod = new Product("Notebook", 1200.0);
 * e a classe product nao tem implementado public override int GetHashCode() e 
 * public override bool Equals(object obj), por mais que os argumentos sejam iguais é um product diferente
 * 
 *a partir do momento que eu faço essa implementação na classe product  o metodo contains(Console.WriteLine(a.Contains(prod))) 
 * passa a considerar verdadeiro essa verificação 
 */
