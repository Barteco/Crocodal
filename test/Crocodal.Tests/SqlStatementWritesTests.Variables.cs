using Crocodal.Core.Expressions;
using Xunit;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_VariableDeclarationExpression()
        {
            // Arrange
            var x = new VariableExpression("x");
            var type = new CustomDbTypeExpression("NCHAR(10)");
            var expression = new VariableDeclarationExpression(x, type);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("DECLARE @x NCHAR(10)", sql);
        }

        [Fact]
        public void Writes_VariableSetExpression()
        {
            // Arrange
            var x = new VariableExpression("x");
            var expression = new VariableSetExpression(x);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("SET @x", sql);
        }
    }
}
