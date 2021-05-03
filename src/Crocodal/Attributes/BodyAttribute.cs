using System;

namespace Crocodal.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BodyAttribute : Attribute
    {
    }
}
