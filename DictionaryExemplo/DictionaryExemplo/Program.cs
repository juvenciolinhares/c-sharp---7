using System;
using System.Collections.Generic;

namespace DictionaryExemplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //implementar um cookie(string chave, string valor)
            Dictionary<string, string> cookies = new Dictionary<string, string>();

            //posso add no conjunto de duas formas
            //1-
            cookies.Add("user", "Maria");
            //2-
            cookies["email"] = "maria@gmail.com";
            cookies["phone"] = "99712234";
            cookies["phone"] = "83737388";//como dictionary n aceita repetição, esse valor vai substituir o anterior
            Console.WriteLine(cookies["phone"]);
            Console.WriteLine(cookies["email"]);

            //remove:
            cookies.Remove("email");
            if (cookies.ContainsKey("email"))
            {
                Console.WriteLine(cookies["email"]);
            }
            else
            {
                Console.WriteLine("There is not 'email' key");
            }

            //tamanho
            Console.WriteLine("Size: " + cookies.Count);

            //imprimir todos:
            Console.WriteLine("ALL COOKIES: ");
            //foreach(var item in cookies)=> SINTAXE ALTERNATIVA MENOS VERBOSA
            foreach (KeyValuePair<string, string> item in cookies)
            {

                Console.WriteLine(item.Key + ": " + item.Value);

            }
        }
    }
}
