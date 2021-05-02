using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace Crocodal.Transpiler.Expressions
{
    public class MultilineExpression : Expression
    {
        public override bool CanReduce => false;
        public override ExpressionType NodeType => ExpressionType.Block;
        public override Type Type => typeof(void);
        public ReadOnlyCollection<Expression> Expressions { get; }

        internal MultilineExpression(params Expression[] expressions)
        {
            Expressions = new ReadOnlyCollection<Expression>(expressions);
        }

        public override string ToString()
        {
            return string.Join("; ", Expressions);
        }
    }
}
