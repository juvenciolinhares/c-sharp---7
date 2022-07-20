using System;
using System.Collections.Generic;

namespace HashSetESortedSetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instancia de um conjunto(importa o System.Collections.Generic;)
            HashSet<string> set = new HashSet<String>();

            //inserir elementos:
            set.Add("TV");
            set.Add("Notebook");
            set.Add("Tablet");

            //teste está contido:
            Console.WriteLine(set.Contains("Notebook"));
           
            //imprimir o conjunto:
            foreach(String p in set)
            {
                Console.WriteLine(p);
            }
        }
    }
}
