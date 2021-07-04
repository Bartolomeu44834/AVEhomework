using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Reflection
{
    PropertyInfo[] compProps;  

    class Comparator : IComparer
    {

        public Comparator(Type entity){

            PropertyInfo[] props = entity.GetProperties();
            PropertyInfo[] compProps = new PropertyInfo(props.Length);
            int count =0;

            foreach(PropertyInfo prop in props){
                Attribute attr = null;
                if(attr = Attribute.GetCustomAttribute(prop, typeof(ComparisonAttribute)) != null && prop.PropertyType.IsAssignableTo(IComparable)){
                    compProps[attr.Idx-1] = prop;
                    count++;
                }
            }
        }

        public int Compare(object x, object y){
            int val;
            for(int i = 0; i< count; i++){
                if(val = compProps[i].GetValue(y).CompareTo(compProps[i].GetValue(x)) != 0){
                    return val;
                }
            }
            return 0;
        }
    }
}