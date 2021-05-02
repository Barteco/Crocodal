using System;
using System.Linq.Expressions;

namespace Crocodal.Transpiler.Expressions
{
    public static class ExpressionBuilder
    {
        public static DeclarationExpression Declaration(Type type, string name)
        {
            return new DeclarationExpression(Expression.Variable(type, name));
        }

        public static Expression Multiline(params Expression[] expressions)
        {
            return expressions.Length switch
            {
                int len when len == 1 => expressions[0],
                int len when len > 1 => new MultilineExpression(expressions),
                _ => throw new InvalidOperationException("You must pass at least one expression as parameter")
            };
        }

        public static ForeachLoopExpression Foreach(ParameterExpression variable, Expression collection, Expression body)
        {
            return new ForeachLoopExpression(variable, collection, body);
        }

        public static ForLoopExpression For(Expression initializer, Expression condition, Expression incrementator, Expression body)
        {
            return new ForLoopExpression(initializer, condition, incrementator, body);
        }

        public static DoWhileLoopExpression DoWhile(Expression condition, Expression body)
        {
            return new DoWhileLoopExpression(condition, body);
        }

        public static WhileLoopExpression While(Expression condition, Expression body)
        {
            return new WhileLoopExpression(condition, body);
        }

        public static TupleExpression Tuple(params Expression[] expressions)
        {
            return new TupleExpression(expressions);
        }
    }
}
