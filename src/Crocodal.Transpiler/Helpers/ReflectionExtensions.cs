using System;
using System.Linq;
using System.Reflection;

namespace Crocodal.Transpiler.Helpers
{
    internal static class ReflectionExtensions
    {
        public static bool IsStatic(this MemberInfo memberInfo)
        {
            return (memberInfo is FieldInfo fieldInfo && fieldInfo.IsStatic)
                || (memberInfo is PropertyInfo propertyInfo && propertyInfo.GetAccessors().Any(e => e.IsStatic));
        }

        public static bool IsGenericTupleType(this Type type)
        {
            if (type.IsGenericType)
            {
                var genType = type.GetGenericTypeDefinition();
                if (genType == typeof(Tuple<>)
                    || genType == typeof(Tuple<,>)
                    || genType == typeof(Tuple<,,>)
                    || genType == typeof(Tuple<,,,>)
                    || genType == typeof(Tuple<,,,,>)
                    || genType == typeof(Tuple<,,,,,>)
                    || genType == typeof(Tuple<,,,,,,>)
                    || genType == typeof(Tuple<,,,,,,,>)
                    || genType == typeof(Tuple<,,,,,,,>))
                    return true;
            }

            return false;
        }
    }
}
