using System;

namespace CustomAttributes{
    public class ComparisonAttribute : Attribute{
        public int index;
        public ComparisonAttribute(int idx){
            index = idx;
        }
    }
}