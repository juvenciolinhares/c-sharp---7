using System;
using ExcLinqLambdaSQL2.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;

namespace ExcLinqLambdaSQL2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);

                        list.Add(new Employee(name, email, salary));
                    }
                    var emails = list.Where(p => p.Salary > limit).OrderBy(x => x.Email).Select(x => x.Email);
                    var sum = list.Where(x => x.Name[0] == 'M').Sum(p => p.Salary);

                    Console.WriteLine("Email of people whose salary is more than " + limit.ToString("F2", CultureInfo.InvariantCulture));
                    foreach (string e in emails)
                    {
                        Console.WriteLine(e);
                    }


                    Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));

                }

            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
/*
 * ler dados de um func(nome, email, salario) em um arquivo .csv
 * 
 * mostrar em ordem alfabetica o email do func com salario superior a um valor 2 fornecido pelo usuario
 * 
 * mostrar soma dos salarios dos func começados com a letra m
 * 
 * C:\testeLinqLambdaSQL2\in.txt
 */

