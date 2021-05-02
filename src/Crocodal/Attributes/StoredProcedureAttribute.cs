using System;

namespace Crocodal.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class StoredProcedureAttribute : Attribute
    {
        private readonly string _name;

        public StoredProcedureAttribute(string name)
        {
            _name = name;
        }
    }
}
