using System;


namespace ExtensionMethodsDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string s1 = "Good mornig dear students!";
            Console.WriteLine(s1.Cut(10));

        }
    }
}
/*
 * criar um extension method chamado Cut(int) que vai gerar um recorte no tamanho original daquele tamanho:
 */
