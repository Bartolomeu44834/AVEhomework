using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Logger
{
    public class Log : AbstractLog
    {
        public Log() : this(new ConsolePrinter())
        {
        }

        public Log(IPrinter p) : base(p)
        {
        }

        public override IEnumerable<IGetter> GetMembers(Type t)
        {
            // First checj if exist in members dictionary
            List<IGetter> ms;
            if(!members.TryGetValue(t, out ms)) {
                ms = new List<IGetter>();
                foreach(MemberInfo m in t.GetMembers()) {
                    IGetter im;
                    if(ShouldLog(m, out im))
                    {
                        ms.Add(im);
                    }
                }
                members.Add(t, ms);
            }
            return ms;
        }

        public override bool ShouldLog(MemberInfo m, out IGetter getter){
            getter = null;
            /**
             * Check if it is annotated with ToLog
             */
            if(!Attribute.IsDefined(m,typeof(ToLogAttribute))) return false;
            ToLogAttribute logAttr = (ToLogAttribute) m.GetCustomAttribute(typeof(ToLogAttribute));
            //logAttr.form.Format(null);
            /**
             * Check if it is a Field
             */
            if(m.MemberType == MemberTypes.Field)
            {
                getter = new IGetterWrapper(new GetterField((FieldInfo) m), logAttr);
                return true;
            }
            /**
             * Check if it is a parameterless method
             */
            if(m.MemberType == MemberTypes.Method  && (m as MethodInfo).GetParameters().Length == 0)
            {
                getter = new IGetterWrapper(new GetterMethod((MethodInfo) m), logAttr);
                return true;
            }

            return false;
        } 

    }

    public class IGetterWrapper : IGetter{

        private IGetter getter;
        private ToLogAttribute logAttr;

        public IGetterWrapper(IGetter method, ToLogAttribute logAttr)
        {
            this.getter = method;
            this.logAttr = logAttr;
        }

        public string GetName()
        {
            return getter.GetName();
        }

        public object GetValue(object target)
        {
            return logAttr.form.Format(getter.GetValue(target));
        }
    }
}