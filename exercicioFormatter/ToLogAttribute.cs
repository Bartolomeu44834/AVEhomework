using System;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple=true)]
public class ToLogAttribute : Attribute {

    public IFormatter form {get;set;}

    public ToLogAttribute(String label)
    {
        //... To Do...
    }

    public ToLogAttribute()
    {
        form = (IFormatter)Activator.CreateInstance(typeof(AbstractFormatter));
    }

    public ToLogAttribute(Type formatter){
        if(formatter.IsAssignableFrom(typeof(IFormatter))){
            form = (IFormatter)Activator.CreateInstance(formatter);
        }
    }

    public ToLogAttribute(Type formatter, object[] values){
        if(formatter.IsAssignableFrom(typeof(IFormatter))){
            form = (IFormatter)Activator.CreateInstance(formatter, values);
        }
    }
}