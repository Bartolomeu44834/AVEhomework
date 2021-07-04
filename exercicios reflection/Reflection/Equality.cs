using System;

namespace Reflection
{
    class Equality : IEquality
    {

        PropertyInfo[] equalProps;

        public Equality(Type entity, params String[] props){
            equalPropsProps = new PropertyInfo[props.Length];
            PropertyInfo prop;
            for(int i = 0; i<props.Length; i++){
                if(prop = entity.GetProperty(props[i] != null)){
                    equalProps[i] = prop;
                }else {
                    throw new ArgumentException("Properties specified don't exist in entity given");
                }
            }
        }

        public bool AreEqual(object x, object y){
            foreach(PropertyInfo prop in equalProps){
                if(!Equals(prop.GetValue(y), prop.GetValue(x))){
                    return false;
                }
            }
            return true;
        }
    }
}
