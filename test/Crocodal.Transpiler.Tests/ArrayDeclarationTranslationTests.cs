using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class ArrayDeclarationTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new();
        private readonly CompilerFixture _fixture;

        public ArrayDeclarationTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType()
        {
            // Arrange
            var unit = _fixture.Compile("int[] x;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Declaration(expression, typeof(int[]), "x");
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType_WithBounds()
        {
            // Arrange
            var unit = _fixture.Compile("int[] x = new int[3];");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int[]), "x");
            var newArray = ExpressionAssert.AsNewArrayBounds(binaryExpression.Right, typeof(int[]));
            ExpressionAssert.Constant(newArray.Expressions[0], 3);
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("int[] x = new int[] { 1, 2, 3 };");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int[]), "x");
            var newArray = ExpressionAssert.AsNewArrayInit(binaryExpression.Right, typeof(int[]), 3);
            ExpressionAssert.ArrayOfConstants(newArray.Expressions, 1, 2, 3);
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType_WithBounds_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("int[] x = new int[3] { 1, 2, 3 };");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int[]), "x");
            var newArray = ExpressionAssert.AsNewArrayInit(binaryExpression.Right, typeof(int[]), 3);
            ExpressionAssert.ArrayOfConstants(newArray.Expressions, 1, 2, 3);
        }

        [Fact]
        public void ShouldParse_ArrayDeclaration_WithExplicitType_WithArrayInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("int[] x = { 1, 2, 3 };");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(int[]), "x");
            var newArray = ExpressionAssert.AsNewArrayInit(binaryExpression.Right, typeof(int[]), 3);
            ExpressionAssert.ArrayOfConstants(newArray.Expressions, 1, 2, 3);
        }
    }
}
