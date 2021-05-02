using System;
using System.Linq.Expressions;

namespace Crocodal.Transpiler.Expressions
{

    public class ForLoopExpression : Expression
    {
        public override bool CanReduce => false;
        public override ExpressionType NodeType => ExpressionType.Loop;
        public override Type Type => typeof(void);

        public Expression Initializer { get; }
        public new Expression Condition { get; }
        public Expression Incrementator { get; }
        public Expression Body { get; }

        public ForLoopExpression(Expression initializer, Expression condition, Expression incrementator, Expression body)
        {
            Initializer = initializer;
            Condition = condition;
            Incrementator = incrementator;
            Body = body;
        }

        public override string ToString()
        {
            return $"for ({Initializer}; {Condition}; {Incrementator}) {Body}";
        }
    }
}
