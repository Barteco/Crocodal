using System;
using System.Linq.Expressions;

namespace Crocodal.Transpiler.Expressions
{

    public class DoWhileLoopExpression : Expression
    {
        public override bool CanReduce => false;
        public override ExpressionType NodeType => ExpressionType.Loop;
        public override Type Type => typeof(void);

        public new Expression Condition { get; }
        public Expression Body { get; }

        public DoWhileLoopExpression(Expression condition, Expression body)
        {
            Condition = condition;
            Body = body;
        }

        public override string ToString()
        {
            return $"while ({Condition}) {Body}";
        }
    }
}
