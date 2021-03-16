using System;

namespace PointApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PointLib.Point p = new PointLib.Point(3,7);

            Console.WriteLine(p.toString());

            Console.WriteLine("p._x = " + p.x);

            Console.WriteLine("p._y = " + p.y);
        }
    }
}
