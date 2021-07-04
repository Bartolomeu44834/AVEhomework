using System;
using DataClasses;
using Interfaces;
using Implementations;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {

            /*Student s1 = new Student(12000, "Ana", new School("NomeEscola","LocationEscola"), "pt");
            Student s2 = new Student(14000, "Ana", new School("NomeEscola","LocationEscola"), "pt");
            IEquality eq1 = new Equality(typeof(Student), new String[] {"Nr", "Name", "School"});
            bool res1 = eq1.AreEqual(s1, s2); // res1 = true se s1 e s2 tiverem o mesmo Nr, Name e School
            IEquality eq2 = new Equality(typeof(Student), new String[] {"Name", "Nationality", "School"});
            bool res2 = eq2.AreEqual(s1, s2); // res2 = true se s1 e s2 tiverem o mesmo Nr e Nationality

            Console.WriteLine("res1 = "+ res1);
            Console.WriteLine("res2 = "+ res2);*/

            Student s1 = new Student(12000, "Ana", new School("NomeEscola","LocationEscola"), "pt");
            Student s2 = new Student(14000, "Ana", new School("NomeEscola","LocationEscola"), "pt");
            Student s3 = new Student(11000, "Ana", new School("NomeEscola","LocationEscola"), "en");
            IComparer cmp = new Comparator(typeof(Student)); // Usa como critérios: 1o nationality e 2o nr
            int res1 = cmp.Compare(s1, s2); // res < 0 porque têm a mesma nationality e 12000 é menor que 14000
            int res2 = cmp.Compare(s2, s3); // res > 0 porque “pt” é maior que “en”

            Console.WriteLine("res1 = "+ res1);
            Console.WriteLine("res2 = "+ res2);

        }
    }
}
