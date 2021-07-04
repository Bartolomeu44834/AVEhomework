using System;

namespace CustomAttributes
{
    public class ComparisonAttribute : Attribute
    {
        public int Idx;

        public ComparisonAttribute(int index){
            this.Idx = index;
        }
    }
}
