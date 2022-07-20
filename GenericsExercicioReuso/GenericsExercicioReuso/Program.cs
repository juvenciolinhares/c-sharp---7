using System;


namespace GenericsExercicioReuso
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vou criar um programa que mexe com o tipo que eu quiser 
            PrintService<int> printService = new PrintService<int>();
            Console.WriteLine("How many values? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                printService.addValue(x);
            }

            printService.Print();
            Console.WriteLine("First: " + printService.first());
        }
    }
}
/*discussão a respeito do generic :
 * se eu quiser um programa que posso aceitar int ou string:
 * 1- solução: criar uma classe printservice recebendo strings em vez de int(funciona, mas não há reuso)
 * 2- solução: usar o object no lugar do int: funciona pro reuso, mas nao tem o type safety e tem problema de performance
 * type safety(tipo salvo): se eu colocar tudo como object eu posso colocar o programa pra somar string com int,
 * double com char etc, por que tudo é object, então usar object não é aconselhavel, vai dar um problema em tempo de execução.
 * isso ainda faz perder performance por causa de boxing e unboxing
 * 
 * solução ideal: ...<T> => parametrização por tipo, vou declara uma variavel t e na hora de declarar o objeto
 * eu vou especificar qual tipo eu quero.
 */
