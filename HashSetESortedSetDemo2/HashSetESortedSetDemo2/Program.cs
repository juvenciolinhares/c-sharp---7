using System;
using System.Collections.Generic;

namespace HashSetESortedSetDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<int> a = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
            SortedSet<int> b = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };
           
            //usando o metodo p imprimir a coleção
            PrintColletcion(a);

            //união entre conjuntos:
            SortedSet<int> c = new SortedSet<int>(a);//instancio c com tds elementos de a
            c.UnionWith(b);//inserindo em c tds os elementos sem repetição
            PrintColletcion(c);//sortedset sempre vai mostrar ordenado(IEnumerable)

            //interseção(elementos que existem nos 2 conj):
           SortedSet<int> d = new SortedSet<int>(a);
            d.IntersectWith(b);
            PrintColletcion(d);

            //diferença:
            SortedSet<int> e = new SortedSet<int>(a);
            e.ExceptWith(b);
            PrintColletcion(e);

        }
        //função pra imprimir o conjunto:
        static void PrintColletcion<T>(IEnumerable<T> collection)
        {
            //foreache funciona em cima de coleções que implem ienumerable:
            foreach(T obj in collection)
            {
                Console.Write(obj + " ");
            }
            Console.WriteLine();
        }
    }
}
/*
 * EXPLICANDO O MÉTODO DE IMPRESSÃO:
 *  static void 
 *  PrintColletcion<T> => imprimir uma coleção genérica
 *  (IEnumerable<T> collection) => IEnumerable: interface implementada por todas as coleções básicas do pacote System.Collections
 * IEnumerable vai retornar um padrão numérico que vai permitir percorrer a coleção (Enumerable: enumeravel, que enumera)
 */
