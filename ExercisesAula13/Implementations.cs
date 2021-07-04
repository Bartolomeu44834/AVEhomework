using System;
using Interfaces;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using CustomAttributes;

namespace Implementations {
    public class Equality : IEquality {
        
        private List<PropertyInfo> propsToComp;

        public Equality(Type entity, String [] props){
            propsToComp = new List<PropertyInfo>();

            foreach(String prop in props){
                propsToComp.Add(entity.GetProperty(prop));
            }
        }

        public bool AreEqual(object x, object y){
            foreach(PropertyInfo prop in propsToComp){
                if( !(prop.GetValue(x).Equals(prop.GetValue(y))) ){
                    return false;
                }
            }
            return true;
        }
    }

    public class Comparator : Interfaces.IComparer {
        
        private PropertyInfo[] propsToComp;
        private int count;

        public Comparator(Type domain){
            PropertyInfo[] props = domain.GetProperties();
            propsToComp = new PropertyInfo[props.Length];
            ComparisonAttribute comp;
            count = 0;
            foreach(PropertyInfo prop in props){
                if(typeof(IComparable).IsAssignableFrom(prop.PropertyType)){
                    if((comp = (ComparisonAttribute)prop.GetCustomAttribute(typeof(ComparisonAttribute)))!= null){
                        propsToComp[comp.index-1] = (prop);
                        count++;
                    }
                }
            }
        }
        
        public int Compare(object x, object y){
            int value;
            for(int i = 0; i< count; i++){
                Object valy = propsToComp[i].GetValue(y);
                IComparable valxComp = propsToComp[i].GetValue(x) as IComparable;
                if((value = valxComp.CompareTo(valy)) != 0){
                    return value;
                }
            }
            return 0;
        }
    }

    public class Comparator2 : Interfaces.IComparer {
        private List<PropertyInfo> propsToComp;

        public Comparator2(Type domain){
            PropertyInfo[] props = domain.GetProperties();
            propsToComp = new List<PropertyInfo>();

            foreach(PropertyInfo prop in props){
                if(typeof(IComparable).IsAssignableFrom(prop.PropertyType) || prop.IsDefined(typeof(ComparisonAttribute))){
                    propsToComp.Add(prop);
                }
            }
        }
        
        public int Compare(object x, object y){
            int res = 0;
            foreach(PropertyInfo prop in propsToComp){
                Object valx = prop.GetValue(x);
                Object valy = prop.GetValue(y);

                if((typeof(IComparable).IsAssignableFrom(prop.PropertyType))){
                    IComparable valxComp = valx as IComparable;
                } else {
                    
                }
                
                /*if( !(valx.Equals(valy)) ){
                    int value = valxComp.CompareTo(valy);
                    if(value != 0){
                        return (res + value);
                    }
                }*/
            }
            return res;
        }
    }
}