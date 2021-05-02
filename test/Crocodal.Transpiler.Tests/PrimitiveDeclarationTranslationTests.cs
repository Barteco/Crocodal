using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System.Linq;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class PrimitiveDeclarationTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public PrimitiveDeclarationTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_PrimitiveTypeDeclaration()
        {
            // Arrange
            var unit = _fixture.Compile("int x;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Declaration(expression, typeof(int), "x");
        }

        [Fact]
        public void ShouldParse_PrimitiveTypeDeclaration_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("int x = 5;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int), "x");
            ExpressionAssert.Constant(binaryExpression.Right, 5);
        }

        [Fact]
        public void ShouldParse_CombinedDeclarations()
        {
            // Arrange
            var unit = _fixture.Compile("int x, y;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression).ToArray();
            Assert.Equal(2, expressions.Length);
            ExpressionAssert.Declaration(expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(expressions[1], typeof(int), "y");
        }

        [Fact]
        public void ShouldParse_CombinedDeclarations_WithInitializers()
        {
            // Arrange
            var unit = _fixture.Compile("int x = 5, y = 6;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression).ToArray();
            Assert.Equal(2, expressions.Length);
            var firstBinaryExpression = ExpressionAssert.AsBinaryAssign(expressions[0]);
            var secondBinaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            ExpressionAssert.Declaration(firstBinaryExpression.Left, typeof(int), "x");
            ExpressionAssert.Constant(firstBinaryExpression.Right, 5);
            ExpressionAssert.Declaration(secondBinaryExpression.Left, typeof(int), "y");
            ExpressionAssert.Constant(secondBinaryExpression.Right, 6);
        }

        [Fact]
        public void ShouldParse_VarDeclaration_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("var x = 5;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int), "x");
            ExpressionAssert.Constant(binaryExpression.Right, 5);
        }

        [Fact]
        public void ShouldParse_VarDeclaration_Passed_To_AnotherStatement_WithCorrectType()
        {
            // Arrange
            var unit = _fixture.Compile("var x = 1; var y = x;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int), "y");
            ExpressionAssert.Parameter(binaryExpression.Right, typeof(int), "x");
        }
    }
}
