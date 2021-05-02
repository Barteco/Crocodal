using System;

namespace Crocodal.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class FunctionAttribute : Attribute
    {
        private readonly string _name;

        public FunctionAttribute(string name)
        {
            _name = name;
        }
    }
}
