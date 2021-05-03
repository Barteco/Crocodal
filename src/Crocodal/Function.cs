using System;

namespace Crocodal
{
    public class Function<TResult>
    {
        public string Name { get; }
        public object Paramters { get; }

        public Function(string name, object paramters)
        {
            Name = name;
            Paramters = paramters;
        }

        public static implicit operator TResult(Function<TResult> self)
        {
            throw new NotImplementedException();
        }
    }
}
