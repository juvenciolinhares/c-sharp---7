using System;
using System.Collections.Generic;


namespace ExtensionMethodsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2022, 07, 20, 8, 10, 45);
            Console.WriteLine(dt.ElapsedTime());//esse método n existe, é um metodo criado por mim na classe estatica
        }
    }
}
