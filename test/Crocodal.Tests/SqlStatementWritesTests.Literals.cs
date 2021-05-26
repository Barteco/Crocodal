using Crocodal.Core.Expressions;
using System;
using Xunit;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_IntLiteralExpression()
        {
            // Arrange
            var expression = new IntLiteralExpression(10);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("10", sql);
        }

        [Fact]
        public void Writes_DoubleLiteralExpression()
        {
            // Arrange
            var expression = new DoubleLiteralExpression(10.5);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("10.5", sql);
        }

        [Fact]
        public void Writes_DecimalLiteralExpression()
        {
            // Arrange
            var expression = new DecimalLiteralExpression(10.5m);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("10.5", sql);
        }

        [Theory]
        [InlineData(true, "N")]
        [InlineData(false, "")]
        public void Writes_StringLiteralExpression(bool isUnicode, string expectedLiteralPrefix)
        {
            // Arrange
            var expression = new StringLiteralExpression("test", isUnicode);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"{expectedLiteralPrefix}'test'", sql);
        }

        [Fact]
        public void Writes_DateLiteralExpression()
        {
            // Arrange
            var expression = new DateLiteralExpression(new DateTime(2021, 5, 2));

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("'2021-05-02'", sql);
        }
    }
}
