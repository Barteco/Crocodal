using System;

namespace Crocodal
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class ReferenceAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BodyAttribute : Attribute
    {
    }
}
