using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System.Linq.Expressions;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class BinaryOperatorTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public BinaryOperatorTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_Addition()
        {
            // Arrange
            var unit = _fixture.Compile("5 + 6");

            // Act
            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Add);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Subtraction()
        {
            // Arrange
            var unit = _fixture.Compile("5 - 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Subtract);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Multiplication()
        {
            // Arrange
            var unit = _fixture.Compile("5 * 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Multiply);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Division()
        {
            // Arrange
            var unit = _fixture.Compile("5 / 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Divide);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Modulo()
        {
            // Arrange
            var unit = _fixture.Compile("5 % 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Modulo);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_LessThan()
        {
            // Arrange
            var unit = _fixture.Compile("5 < 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.LessThan);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_LessThanOrEqual()
        {
            // Arrange
            var unit = _fixture.Compile("5 <= 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.LessThanOrEqual);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_GreaterThan()
        {
            // Arrange
            var unit = _fixture.Compile("5 > 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.GreaterThan);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_GreaterThanOrEqual()
        {
            // Arrange
            var unit = _fixture.Compile("5 >= 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.GreaterThanOrEqual);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_Equal()
        {
            // Arrange
            var unit = _fixture.Compile("5 == 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Equal);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_NotEqual()
        {
            // Arrange
            var unit = _fixture.Compile("5 != 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.NotEqual);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_ConditionalAnd()
        {
            // Arrange
            var unit = _fixture.Compile("true && false");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.AndAlso);
            ExpressionAssert.Constant(binaryExpression.Left, true);
            ExpressionAssert.Constant(binaryExpression.Right, false);
        }

        [Fact]
        public void ShouldParse_ConditionalOr()
        {
            // Arrange
            var unit = _fixture.Compile("true || false");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.OrElse);
            ExpressionAssert.Constant(binaryExpression.Left, true);
            ExpressionAssert.Constant(binaryExpression.Right, false);
        }

        [Fact]
        public void ShouldParse_ParenthesizedExpression()
        {
            // Arrange
            var unit = _fixture.Compile("(5 + 6)");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Add);
            ExpressionAssert.Constant(binaryExpression.Left, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_OperatorPrecedence()
        {
            // Arrange
            var unit = _fixture.Compile("4 * 5 + 6");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinary(expression, ExpressionType.Add);
            var binarySubExpression = ExpressionAssert.AsBinary(binaryExpression.Left, ExpressionType.Multiply);
            ExpressionAssert.Constant(binarySubExpression.Left, 4);
            ExpressionAssert.Constant(binarySubExpression.Right, 5);
            ExpressionAssert.Constant(binaryExpression.Right, 6);
        }
    }
}
