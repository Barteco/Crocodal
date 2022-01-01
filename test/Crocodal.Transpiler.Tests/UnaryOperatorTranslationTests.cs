using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System.Linq.Expressions;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class UnaryOperatorTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new();
        private readonly CompilerFixture _fixture;

        public UnaryOperatorTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_Not()
        {
            // Arrange
            var unit = _fixture.Compile("!true;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var unaryExpression = ExpressionAssert.AsUnary(expression, ExpressionType.Not);
            ExpressionAssert.Constant(unaryExpression.Operand, true);
        }

        [Fact]
        public void ShouldParse_Minus()
        {
            // Arrange
            var unit = _fixture.Compile("-5");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var unaryExpression = ExpressionAssert.AsUnary(expression, ExpressionType.Negate);
            ExpressionAssert.Constant(unaryExpression.Operand, 5);
        }

        [Fact]
        public void ShouldParse_Plus()
        {
            // Arrange
            var unit = _fixture.Compile("+5");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var unaryExpression = ExpressionAssert.AsUnary(expression, ExpressionType.UnaryPlus);
            ExpressionAssert.Constant(unaryExpression.Operand, 5);
        }

        [Fact]
        public void ShouldParse_PostfixIncrement()
        {
            // Arrange
            var unit = _fixture.Compile("int i = 0; i++;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var unaryExpression = ExpressionAssert.AsUnary(expressions[1], ExpressionType.PostIncrementAssign);
            ExpressionAssert.Parameter(unaryExpression.Operand, typeof(int), "i");
        }

        [Fact]
        public void ShouldParse_PrefixIncrement()
        {
            // Arrange
            var unit = _fixture.Compile("int i = 0; ++i;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var unaryExpression = ExpressionAssert.AsUnary(expressions[1], ExpressionType.PreIncrementAssign);
            ExpressionAssert.Parameter(unaryExpression.Operand, typeof(int), "i");
        }

        [Fact]
        public void ShouldParse_PostfixDecrement()
        {
            // Arrange
            var unit = _fixture.Compile("int i = 0; i--;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var unaryExpression = ExpressionAssert.AsUnary(expressions[1], ExpressionType.PostDecrementAssign);
            ExpressionAssert.Parameter(unaryExpression.Operand, typeof(int), "i");
        }

        [Fact]
        public void ShouldParse_PrefixDecrement()
        {
            // Arrange
            var unit = _fixture.Compile("int i = 0; --i;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var unaryExpression = ExpressionAssert.AsUnary(expressions[1], ExpressionType.PreDecrementAssign);
            ExpressionAssert.Parameter(unaryExpression.Operand, typeof(int), "i");
        }
    }
}
