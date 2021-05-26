using Crocodal.Core.Expressions;
using Xunit;

namespace Crocodal.Tests
{
    public partial class SqlStatementWritesTests
    {
        [Fact]
        public void Writes_IntDbType()
        {
            // Arrange
            var expression = new IntDbTypeExpression();

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("INT", sql);
        }

        [Fact]
        public void Writes_DoubleDbType()
        {
            // Arrange
            var expression = new DoubleDbTypeExpression();

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("FLOAT(53)", sql);
        }

        [Fact]
        public void Writes_DecimalDbType()
        {
            // Arrange
            var expression = new DecimalDbTypeExpression(10, 2);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("DECIMAL(10, 2)", sql);
        }

        [Theory]
        [InlineData(true, null, "N", "MAX")]
        [InlineData(false, null, "", "MAX")]
        [InlineData(true, 128, "N", "128")]
        [InlineData(false, 128, "", "128")]
        public void Writes_StringDbType(bool isUnicode, int? maxLength, string expectedTypePrefix, string expectedLength)
        {
            // Arrange
            var expression = new StringDbTypeExpression(isUnicode, maxLength);

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal($"{expectedTypePrefix}VARCHAR({expectedLength})", sql);
        }

        [Fact]
        public void Writes_CustomDbType()
        {
            // Arrange
            var expression = new CustomDbTypeExpression("NCHAR(10)");

            // Act
            var sql = _writer.Write(expression);

            // Assert
            Assert.Equal("NCHAR(10)", sql);
        }
    }
}
