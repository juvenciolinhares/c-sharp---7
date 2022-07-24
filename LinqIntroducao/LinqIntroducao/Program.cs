using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqIntroducao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //especificar o data source
            int[] numbers = new int[] { 2, 3, 4, 5 };

            /*definir a expressão da consulta(query):
            *regra: pego os num pares e multiplico por 10, gerando uma nova coleção 
            *where: filtra os dados de acordo com o predicado informado como argumento
            IEnumerable gera uma coleção mais genérica
            */
            IEnumerable<int> result = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * 10);//usei 2 pred.: 1- num par, 2- multp num par por 10
            
            //sintaxe alternativa: var result = numbers.Where(x => x % 2 == 0).Select(x => x * 10);

            //executar a consulta:
            foreach(int x in result)
            {
                Console.WriteLine(x);
            }
        }
    }
}

/*linq é composto por varios extension metods atrelados às coleções
 * pipeline: "gera um predicado depois do outro:"
 * var result = numbers.Where(x => x % 2 == 0).Select(x => x * 10);
 */
