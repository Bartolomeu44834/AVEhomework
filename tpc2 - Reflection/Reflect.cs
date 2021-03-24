using System;
using System.Reflection;

namespace tpc2___Reflection
{
    class REflect
    {
        static void Main(string[] args)
        {

            Assembly a = Assembly.Load ( "RestSharp" );
            Type[] types = a.GetTypes();

            foreach(var t in types){
                Console.WriteLine(t.Name);

                MethodInfo[] methods = t.GetMethods();

                foreach(var curr in methods){
                    Console.WriteLine("\t" + curr.Name);
                }
            }
            
        }
    }
}
