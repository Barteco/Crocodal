using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class GenericsDeclarationTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public GenericsDeclarationTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithSingleParam()
        {
            // Arrange
            var unit = _fixture.Compile("List<string> x;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Declaration(expression, typeof(List<string>), "x");
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithSingleParam_WithQualifiedName()
        {
            // Arrange
            var unit = _fixture.Compile("System.Collections.Generic.List<string> x;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Declaration(expression, typeof(List<string>), "x");
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithSingleParam_WithInitializer()
        {
            // Arrange
            // Arrange
            var unit = _fixture.Compile("List<string> x = new List<string>();");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(List<string>), "x");
            ExpressionAssert.New(binaryExpression.Right, typeof(List<string>), Enumerable.Empty<Type>());
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithSingleParam_WithInitializer_WithQualifiedName()
        {
            // Arrange
            var unit = _fixture.Compile("System.Collections.Generic.List<string> x = new System.Collections.Generic.List<string>();");

            // Act
            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(List<string>), "x");
            ExpressionAssert.New(binaryExpression.Right, typeof(List<string>), Enumerable.Empty<Type>());
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithMultipleParams()
        {
            // Arrange
            var unit = _fixture.Compile("Dictionary<string, string> x;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            ExpressionAssert.Declaration(expression, typeof(Dictionary<string, string>), "x");
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithMultipleParams_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("Dictionary<string, string> x = new Dictionary<string, string>();");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(Dictionary<string, string>), "x");
            ExpressionAssert.New(binaryExpression.Right, typeof(Dictionary<string, string>), Enumerable.Empty<Type>());
        }
    }
}
