using System;

namespace tpc3___Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(154134, "Ze Manel", 5243, "ze");
            Student s2 = new Student(154134, "Xico", 1234, "xico");
            Account a = new Account(1300);

            Log l = new Log();

            l.Info(s1);
            l.Info(s2);
            l.Info(a);
        }
    }
}
