using System.Reflection;

public class GetterField : IGetter
{
    private readonly FieldInfo field;

    public GetterField(FieldInfo method)
    {
        this.field = method;
    }

    public string GetName()
    {
        return field.Name;
    }

    public object GetValue(object target)
    {
        return field.GetValue(target);
    }
}