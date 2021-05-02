using Crocodal.Transpiler.Tests.Core;
using System.Linq.Expressions;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class UnaryOperatorTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_Not()
        {
            var unit = Compiler.Compile("!true;");

            var expression = _translator.Translate(unit);

            var unaryExpression = ExpressionAssert.AsUnary(expression, ExpressionType.Not);
            ExpressionAssert.Constant(unaryExpression.Operand, true);
        }

        [Fact]
        public void ShouldParse_Minus()
        {
            var unit = Compiler.Compile("-5");

            var expression = _translator.Translate(unit);

            var unaryExpression = ExpressionAssert.AsUnary(expression, ExpressionType.Negate);
            ExpressionAssert.Constant(unaryExpression.Operand, 5);
        }

        [Fact]
        public void ShouldParse_Plus()
        {
            var unit = Compiler.Compile("+5");

            var expression = _translator.Translate(unit);

            var unaryExpression = ExpressionAssert.AsUnary(expression, ExpressionType.UnaryPlus);
            ExpressionAssert.Constant(unaryExpression.Operand, 5);
        }

        [Fact]
        public void ShouldParse_PostfixIncrement()
        {
            var unit = Compiler.Compile("int i = 0; i++;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var unaryExpression = ExpressionAssert.AsUnary(expressions[1], ExpressionType.PostIncrementAssign);
            ExpressionAssert.Parameter(unaryExpression.Operand, typeof(int), "i");
        }

        [Fact]
        public void ShouldParse_PrefixIncrement()
        {
            var unit = Compiler.Compile("int i = 0; ++i;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var unaryExpression = ExpressionAssert.AsUnary(expressions[1], ExpressionType.PreIncrementAssign);
            ExpressionAssert.Parameter(unaryExpression.Operand, typeof(int), "i");
        }

        [Fact]
        public void ShouldParse_PostfixDecrement()
        {
            var unit = Compiler.Compile("int i = 0; i--;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var unaryExpression = ExpressionAssert.AsUnary(expressions[1], ExpressionType.PostDecrementAssign);
            ExpressionAssert.Parameter(unaryExpression.Operand, typeof(int), "i");
        }

        [Fact]
        public void ShouldParse_PrefixDecrement()
        {
            var unit = Compiler.Compile("int i = 0; --i;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var unaryExpression = ExpressionAssert.AsUnary(expressions[1], ExpressionType.PreDecrementAssign);
            ExpressionAssert.Parameter(unaryExpression.Operand, typeof(int), "i");
        }
    }
}
