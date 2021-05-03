using System;

namespace Crocodal.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class ReferenceAttribute : Attribute
    {
    }
}
