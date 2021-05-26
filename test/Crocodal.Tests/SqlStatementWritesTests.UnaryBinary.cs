using Crocodal.Core.Expressions;
using System;
using Xunit;
using Operator = System.Linq.Expressions.ExpressionType;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Theory]
        [InlineData(Operator.AndAlso, "AND")]
        [InlineData(Operator.OrElse, "OR")]
        [InlineData(Operator.Assign, "=")]
        [InlineData(Operator.Equal, "=")]
        [InlineData(Operator.NotEqual, "<>")]
        [InlineData(Operator.GreaterThan, ">")]
        [InlineData(Operator.GreaterThanOrEqual, ">=")]
        [InlineData(Operator.LessThan, "<")]
        [InlineData(Operator.LessThanOrEqual, "<=")]
        [InlineData(Operator.Add, "+")]
        [InlineData(Operator.Subtract, "-")]
        [InlineData(Operator.Multiply, "*")]
        [InlineData(Operator.Divide, "/")]
        [InlineData(Operator.Modulo, "%")]
        public void Writes_BinaryExpression(Operator @operator, string expectedOperator)
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var expression = new BinaryExpression(x, y, @operator);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"[x] {expectedOperator} [y]", sql);
        }

        [Theory]
        [InlineData("and", "and", "and", false, false)]
        [InlineData("and", "and", "or", true, true)]
        [InlineData("or", "and", "and", true, true)]
        [InlineData("or", "and", "or", true, true)]
        [InlineData("or", "or", "or", false, false)]
        [InlineData("or", "or", "and", true, true)]
        [InlineData("and", "or", "or", true, true)]
        [InlineData("and", "or", "and", true, true)]
        [InlineData("eq", "and", "and", false, false)]
        [InlineData("and", "and", "eq", false, false)]
        public void Writes_BinaryExpression_Parenthesis(string left, string middle, string right, bool expectLeftParens, bool expectRightParens)
        {
            // Arrange
            var n = new IntLiteralExpression(1);
            var equals = new BinaryExpression(n, n, Operator.Equal);
            var or = new BinaryExpression(equals, equals, Operator.OrElse);
            var and = new BinaryExpression(equals, equals, Operator.AndAlso);
            var middleOp = middle == "and" ? Operator.AndAlso : Operator.OrElse;
            var leftExp = left == "and" ? and : (left == "or" ? or : equals);
            var rightExp = right == "and" ? and : (right == "or" ? or : equals);
            var expression = new BinaryExpression(leftExp, rightExp, middleOp);

            var expectedMiddleOperator = middle == "and" ? "AND" : "OR";
            var expectedLeftExpression = left == "and" ? "1 = 1 AND 1 = 1" : (left == "or" ? "1 = 1 OR 1 = 1" : "1 = 1");
            var expectedRightExpression = right == "and" ? "1 = 1 AND 1 = 1" : (right == "or" ? "1 = 1 OR 1 = 1" : "1 = 1");
            if (expectLeftParens)
                expectedLeftExpression = $"\\({expectedLeftExpression}\\)";
            if (expectRightParens)
                expectedRightExpression = $"\\({expectedRightExpression}\\)";

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Matches($"^{expectedLeftExpression} {expectedMiddleOperator} {expectedRightExpression}$", sql);
        }

        [Fact]
        public void Throws_On_UnsupportedBinaryOperator()
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var expression = new BinaryExpression(x, y, Operator.Try);

            // Act
            Action action = () => _writer.Write(expression);

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Theory]
        [InlineData(Operator.UnaryPlus, "+")]
        [InlineData(Operator.Negate, "-")]
        public void Writes_UnaryExpression(Operator @operator, string expectedOperator)
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var expression = new UnaryExpression(x, @operator);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"{expectedOperator}[x]", sql);
        }

        [Fact]
        public void Throws_On_UnsupportedUnaryOperator()
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var expression = new UnaryExpression(x, Operator.Try);

            // Act
            Action action = () => _writer.Write(expression);

            // Assert
            Assert.Throws<InvalidOperationException>(action);
        }
    }
}
