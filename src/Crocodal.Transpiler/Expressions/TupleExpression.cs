using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace Crocodal.Transpiler.Expressions
{
    public class TupleExpression : Expression
    {
        public override bool CanReduce => false;
        public override ExpressionType NodeType => ExpressionType.Parameter;
        private Type _type;
        public override Type Type => _type;
        public ReadOnlyCollection<Expression> Expressions { get; }
        public int Rank => Expressions.Count;

        internal TupleExpression(params Expression[] expressions)
        {
            Expressions = new ReadOnlyCollection<Expression>(expressions);
            _type = GetGenericTupleType(Expressions.Count).MakeGenericType(Expressions.Select(e => e.Type).ToArray());
        }

        public override string ToString()
        {
            return $"({string.Join(", ", Expressions)})";
        }

        private Type GetGenericTupleType(int n)
        {
            switch (n)
            {
                case 1: return typeof(Tuple<>);
                case 2: return typeof(Tuple<,>);
                case 3: return typeof(Tuple<,,>);
                case 4: return typeof(Tuple<,,,>);
                case 5: return typeof(Tuple<,,,,>);
                case 6: return typeof(Tuple<,,,,,>);
                case 7: return typeof(Tuple<,,,,,,>);
                default: throw new ArgumentException("Tuple are supported with max 7 component");
            }
        }
    }
}
