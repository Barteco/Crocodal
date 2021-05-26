using Crocodal.Core.Expressions;
using Xunit;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_IdentifierExpression()
        {
            // Arrange
            var expression = new IdentifierExpression("x");

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("[x]", sql);
        }

        [Fact]
        public void Writes_ComplexIdentifierExpression()
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var expression = new ComplexIdentifierExpression(x, y);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("[x].[y]", sql);
        }

        [Fact]
        public void Writes_VariableExpression()
        {
            // Arrange
            var expression = new VariableExpression("x");

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("@x", sql);
        }

        [Fact]
        public void Writes_TemporaryTableExpression()
        {
            // Arrange
            var expression = new TemporaryTableExpression("x");

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("#x", sql);
        }

        [Fact]
        public void Writes_AliasExpression()
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var expression = new AliasExpression(x, y);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("[x] AS [y]", sql);
        }
    }
}
