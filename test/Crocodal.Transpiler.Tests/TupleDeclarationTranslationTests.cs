using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class TupleDeclarationTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public TupleDeclarationTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Explicit_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("Tuple<int, int> x = (5, 6);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(Tuple<int, int>), "x");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_AsVar_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("var x = (5, 6);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(Tuple<int, int>), "x");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Upacked_WithExplicitTypesInside_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("(int x, int y) = (5, 6);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var leftExpression = ExpressionAssert.AsTuple(binaryExpression.Left);
            Assert.Equal(2, leftExpression.Rank);
            ExpressionAssert.Declaration(leftExpression.Expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(leftExpression.Expressions[1], typeof(int), "y");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Upacked_WithVarsInside_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("(var x, var y) = (5, 6);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var leftExpression = ExpressionAssert.AsTuple(binaryExpression.Left);
            Assert.Equal(2, leftExpression.Rank);
            ExpressionAssert.Declaration(leftExpression.Expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(leftExpression.Expressions[1], typeof(int), "y");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Upacked_WithExplicitTypeOutside_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("int (x, y) = (5, 6);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var leftExpression = ExpressionAssert.AsTuple(binaryExpression.Left);
            Assert.Equal(2, leftExpression.Rank);
            ExpressionAssert.Declaration(leftExpression.Expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(leftExpression.Expressions[1], typeof(int), "y");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }

        [Fact]
        public void ShouldParse_TupleDeclaration_Upacked_WithVarOutside_WithInitializer()
        {
            // Arrange
            var unit = _fixture.Compile("var (x, y) = (5, 6);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var leftExpression = ExpressionAssert.AsTuple(binaryExpression.Left);
            Assert.Equal(2, leftExpression.Rank);
            ExpressionAssert.Declaration(leftExpression.Expressions[0], typeof(int), "x");
            ExpressionAssert.Declaration(leftExpression.Expressions[1], typeof(int), "y");
            var rightExpression = ExpressionAssert.AsTuple(binaryExpression.Right);
            Assert.Equal(2, rightExpression.Rank);
            ExpressionAssert.Constant(rightExpression.Expressions[0], 5);
            ExpressionAssert.Constant(rightExpression.Expressions[1], 6);
        }
    }
}
