using System;
using System.Linq.Expressions;

namespace Crocodal.Transpiler.Expressions
{
    public class ForeachLoopExpression : Expression
    {
        public override bool CanReduce => false;
        public override ExpressionType NodeType => ExpressionType.Loop;
        public override Type Type => typeof(void);

        public new ParameterExpression Variable { get; }
        public Expression Collection { get; }
        public Expression Body { get; }

        public ForeachLoopExpression(ParameterExpression variable, Expression collection, Expression body)
        {
            Variable = variable;
            Collection = collection;
            Body = body;
        }

        public override string ToString()
        {
            return $"foreach ({Variable.Type.Name} {Variable.Name} in {Collection}) {Body}";
        }
    }
}
