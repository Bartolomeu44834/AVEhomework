using System.Reflection;

namespace Interfaces{
    public interface IValidation { 
        PropertyInfo prop {get; set;}
        bool Validate(object obj); 
    }
}
