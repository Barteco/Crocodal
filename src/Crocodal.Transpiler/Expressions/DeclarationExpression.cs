using System;
using System.Linq.Expressions;

namespace Crocodal.Transpiler.Expressions
{
    public class DeclarationExpression : Expression
    {
        public override bool CanReduce => false;
        public override ExpressionType NodeType => ExpressionType.Parameter;
        public override Type Type => Parameter.Type;
        public new ParameterExpression Parameter { get; }

        internal DeclarationExpression(ParameterExpression parameter)
        {
            Parameter = parameter;
        }

        public override string ToString()
        {
            return $"{Type.Name} {Parameter.Name}";
        }
    }
}
