using Crocodal.Core.Expressions;
using Xunit;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_Select_OnlyColumns()
        {
            // Arrange
            var literal1 = new IntLiteralExpression(1);
            var literal2 = new IntLiteralExpression(2);
            var columns = new ColumnListExpression(literal1, literal2);
            var expression = new SelectExpression(columns);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("SELECT 1, 2", sql);
        }

        [Fact]
        public void Writes_Select_Column_From_Source()
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var columns = new ColumnListExpression(x);
            var from = new FromListExpression(y);
            var expression = new SelectExpression(columns, from);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"SELECT [x]{NewLine}FROM [y]", sql);
        }

        [Fact]
        public void Writes_Select_Column_From_MultipleSource()
        {
            // Arrange
            var x = new IdentifierExpression("x");
            var y = new IdentifierExpression("y");
            var z = new IdentifierExpression("z");
            var columns = new ColumnListExpression(x);
            var from = new FromListExpression(y, z);
            var expression = new SelectExpression(columns, from);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"SELECT [x]{NewLine}FROM [y], [z]", sql);
        }
    }
}
