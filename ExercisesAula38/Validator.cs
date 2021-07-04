using Interfaces;
using System.Reflection;
using System;

namespace Implementations{
    public class Validator<T>{

        public delegate bool Valid(object obj);
        public Valid valid;
        public Validator() {
            
        }

        public Validator(Valid validation){
            valid = validation;
        }

        public Validator<T> AddValidation(string prop, IValidation validation) {
            validation.prop = default(T).GetType().GetProperty(prop);
            return new Validator<T>(valid + validation.Validate);
        }

        public void Validate(object obj){
            if(valid != null ){
                if(!valid.Invoke(obj)){
                    throw new ValidationException();
                }
            }
        } 
    }

    public class ValidationException : System.Exception{
        public ValidationException(){

        }
    }

    public class Above18 : IValidation{
        
        public PropertyInfo prop {get; set;}
        public Above18(){

        }

        public bool Validate(object obj){
            return (int)prop.GetValue(obj) > 18;
        }
    }
}
