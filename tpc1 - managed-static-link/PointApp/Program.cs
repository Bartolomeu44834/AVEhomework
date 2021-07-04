using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace PointApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PointLib.Point p = new PointLib.Point(3,7);

            FieldInfo[] propsInfo = p.GetType().GetFields();

            Dictionary<string, object> dic = new Dictionary<string, object>();

            foreach(FieldInfo prop in propsInfo){
                Console.WriteLine("Field " + prop.Name);
                dic.Add(prop.Name, prop.GetValue(p));
            }
            object xo = new int();
            object yo = new int();
            dic.TryGetValue("x", out xo);
            dic.TryGetValue("y", out yo);

            Console.WriteLine(dic.ToString());

            if(xo != null){
                Console.WriteLine("x = " + xo.ToString());
                Console.WriteLine("y = " + yo.ToString());
            }
           
            
            
            
            /*int x=3;
            int y=7;

            Type t  = typeof(PointLib.Point);
            Type objec = typeof(Object);
            FieldInfo[] fields = t.GetFields();
            Object[] values = new object[fields.Length];
            Type[] types = new Type[fields.Length];

            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add("x", x);
            dic.Add("y", y);

            for(int i = 0; i< fields.Length; i++){
                types[i] = fields[i].FieldType;
                dic.TryGetValue(fields[i].Name, out values[i]);
            }

            
            ConstructorInfo ctr = t.GetConstructor(types);
            if(ctr != null){
                PointLib.Point poin = (PointLib.Point)ctr.Invoke(values);
                Console.WriteLine(poin.toString());
            }else{
                Console.WriteLine("unsuccessful");
            }*/
            

            //Console.WriteLine("p._x = " + obj.x);

            //Console.WriteLine("p._y = " + obj.y);
        }
    }
}
