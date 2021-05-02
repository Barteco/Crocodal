using Crocodal.Transpiler.Tests.Core;
using System.Linq.Expressions;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class BinaryOperatorTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_Addition()
        {
            var unit = Compiler.Compile("5 + 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Add);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Subtraction()
        {
            var unit = Compiler.Compile("5 - 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Subtract);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Multiplication()
        {
            var unit = Compiler.Compile("5 * 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Multiply);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Division()
        {
            var unit = Compiler.Compile("5 / 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Divide);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Modulo()
        {
            var unit = Compiler.Compile("5 % 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Modulo);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_LessThan()
        {
            var unit = Compiler.Compile("5 < 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.LessThan);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_LessThanOrEqual()
        {
            var unit = Compiler.Compile("5 <= 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.LessThanOrEqual);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_GreaterThan()
        {
            var unit = Compiler.Compile("5 > 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.GreaterThan);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_GreaterThanOrEqual()
        {
            var unit = Compiler.Compile("5 >= 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.GreaterThanOrEqual);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Equal()
        {
            var unit = Compiler.Compile("5 == 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Equal);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_NotEqual()
        {
            var unit = Compiler.Compile("5 != 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.NotEqual);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_ConditionalAnd()
        {
            var unit = Compiler.Compile("true && false");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.AndAlso);
            ExpressionAssert.Constant(binaryExpression.Left, true);
            ExpressionAssert.Constant(binaryExpression.Right, false);
        }

        [Fact]
        public void ShouldParse_ConditionalOr()
        {
            var unit = Compiler.Compile("true || false");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.OrElse);
            ExpressionAssert.Constant(binaryExpression.Left, true);
            ExpressionAssert.Constant(binaryExpression.Right, false);
        }

        [Fact]
        public void ShouldParse_ParenthesizedExpression()
        {
            var unit = Compiler.Compile("(5 + 6)");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Add);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_OperatorPrecedence()
        {
            var unit = Compiler.Compile("4 * 5 + 6");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Add);
            var binarySubExpression = ExpressionAssert.AsBinary(binaryExpression.Left, ExpressionType.Multiply);
            ExpressionAssert.Constant(binarySubExpression.Left, 4);
            ExpressionAssert.Constant(binarySubExpression.Right, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }
    }
}
