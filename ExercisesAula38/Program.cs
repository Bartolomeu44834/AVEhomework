using System;
using System.Reflection;
using Implementations;
using DataClasses;

namespace ExercisesAula38
{
    class Program
    {
        static void Main(string[] args)
        {
            Validator<Student> validator1 = new Validator<Student>().AddValidation("Age", new Above18());
            //Validator<Student> validator2 = validator1.AddValidation("Name", new NotNull());
            Student s = new Student(); s.Age = 20; s.Name = null;
            validator1.Validate(s); // => succesful 
            //validator2.Validate(s); // => ValidationException
        }
    }
}
