using System;
using System.Collections.Generic;

namespace ExcPropHashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //conjuntos:
            HashSet<int> CourseA = new HashSet<int>();
            HashSet<int> CourseB = new HashSet<int>();
            HashSet<int> CourseC = new HashSet<int>();

            //armazenar estudantes por curso:
            Console.Write("How Many students for course A? ");
            int studentsA = int.Parse(Console.ReadLine());

            for(int i = 0; i < studentsA; i++)
            {
                int codeA = int.Parse(Console.ReadLine());
                CourseA.Add(codeA);
            }
            Console.Write("How Many students for course B? ");
            int studentsB = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsB; i++)
            {
                int codeB = int.Parse(Console.ReadLine());
                CourseB.Add(codeB);
            }
            Console.Write("How Many students for course C? ");
            int studentsC = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsC; i++)
            {
                int codeC = int.Parse(Console.ReadLine());
                CourseC.Add(codeC);
            }

            //compilar as listas e imprimir o total:
            HashSet<int> AllCourses = new HashSet<int>(CourseA);
            AllCourses.UnionWith(CourseB);
            AllCourses.UnionWith(CourseC);
            Console.WriteLine("Total Students: " + AllCourses.Count);

        }
    }
}
/*
* cada aluno possui um id
*cada aluno se matricula em qts cursos quiser
*o instrutor possui 3 cursos: a,b,c e quer saber o total de alunos
*ler os alunos do curso a,b,c do instrutor alex 
*mostrar qtd total de alunos

 */