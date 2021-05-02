using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class NullableDeclarationTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public NullableDeclarationTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_NullableTypeDeclaration()
        {
            // Arrange
            var unit = _fixture.Compile("int? x;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Declaration(expression, typeof(int?), "x");
        }

        [Fact]
        public void ShouldParse_NullableTypeDeclaration_WithQualifiedName()
        {
            // Arrange
            var unit = _fixture.Compile("Nullable<int> x;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Declaration(expression, typeof(int?), "x");
        }

        [Fact]
        public void ShouldParse_NullableTypeDeclaration_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("int? x = 5;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int?), "x");
            ExpressionAssert.Constant(binaryExpression.Right, 5);
        }

        [Fact]
        public void ShouldParse_NullableTypeDeclaration_WithInitializer_WithQualifiedName()
        {
            // Arrange
            var unit = _fixture.Compile("Nullable<int> x = 5;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int?), "x");
            ExpressionAssert.Constant(binaryExpression.Right, 5);
        }
    }
}
