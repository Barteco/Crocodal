using Crocodal.Core.Expressions;
using Xunit;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_Union()
        {
            // Arrange
            var left = BuildSimpleSelectExpression(1);
            var right = BuildSimpleSelectExpression(2);
            var expression = new UnionExpression(left, right);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"SELECT 1{NewLine}UNION{NewLine}SELECT 2", sql);
        }

        [Fact]
        public void Writes_UnionAll()
        {
            // Arrange
            var left = BuildSimpleSelectExpression(1);
            var right = BuildSimpleSelectExpression(2);
            var expression = new UnionAllExpression(left, right);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"SELECT 1{NewLine}UNION ALL{NewLine}SELECT 2", sql);
        }

        private SelectExpression BuildSimpleSelectExpression(int n)
        {
            var literal = new IntLiteralExpression(n);
            var list = new ColumnListExpression(literal);
            return new SelectExpression(list);
        }
    }
}
