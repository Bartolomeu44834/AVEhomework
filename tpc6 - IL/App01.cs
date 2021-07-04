using System;

class App01{
    public static void Foo(int nr){
        Console.Write(nr + ",");
        if(nr==1){
            Console.WriteLine();
            return;
        }

        if(nr%2 != 0) return Foo(nr/2);
        
        return Foo(nr*3+1);
    }
}