using System;
using System.IO;
using ExcResolvidoConjuntos.Entities;
using System.Collections.Generic;

namespace ExcResolvidoConjuntos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instanciar o conjunto(vou escolher o hashset pq a ordem não importa):
            HashSet<LogRecord> set = new HashSet<LogRecord>();

            //ACESSASR E LER O ARQUIVO COM AS INFORMAÇÕES:
            Console.WriteLine("Enter Full path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        //fazer a leitura dos dados pegando username e instant:
                        string[] line = sr.ReadLine().Split(' ');
                        string userName = line[0];
                        DateTime instant = DateTime.Parse(line[1]);
                        set.Add(new LogRecord { UserName = userName, Instant = instant });//não entre nome repetido pq implem GetHashCode e Equals
                       
                    }
                    //imprimir a qtd de usuarios
                    Console.WriteLine("Total users: " + set.Count);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
//C:\excResolvidoConjuntos\in.txt