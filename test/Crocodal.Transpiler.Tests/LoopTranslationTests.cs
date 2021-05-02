using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class LoopTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new StatementTranslator();
        private readonly CompilerFixture _fixture;

        public LoopTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_While_WithEmptyBody()
        {
            // Arrange
            var unit = _fixture.Compile("while(true) { }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var whileStatement = ExpressionAssert.AsWhileLoop(expression);
            ExpressionAssert.Constant(whileStatement.Condition, true);
            var loopExpressions = ExpressionAssert.AsBlock(whileStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_While_WithBody()
        {
            // Arrange
            var unit = _fixture.Compile("while(true) { var x = true; }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var whileStatement = ExpressionAssert.AsWhileLoop(expression);
            ExpressionAssert.Constant(whileStatement.Condition, true);
            var loopExpressions = ExpressionAssert.AsBlock(whileStatement.Body);
            Assert.Single(loopExpressions);
        }

        [Fact]
        public void ShouldParse_While_WithBody_WithoutBraces()
        {
            // Arrange
            var unit = _fixture.Compile("while(true) var x = true;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var whileStatement = ExpressionAssert.AsWhileLoop(expression);
            ExpressionAssert.Constant(whileStatement.Condition, true);
            ExpressionAssert.AsBinaryAssign(whileStatement.Body);
        }

        [Fact]
        public void ShouldParse_DoWhile_WithEmptyBody()
        {
            // Arrange
            var unit = _fixture.Compile("do { } while(true);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var doWhileStatement = ExpressionAssert.AsDoWhileLoop(expression);
            ExpressionAssert.Constant(doWhileStatement.Condition, true);
            var loopExpressions = ExpressionAssert.AsBlock(doWhileStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_DoWhile_WithBody()
        {
            // Arrange
            var unit = _fixture.Compile("do { var x = true; } while(true);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var doWhileStatement = ExpressionAssert.AsDoWhileLoop(expression);
            ExpressionAssert.Constant(doWhileStatement.Condition, true);
            var loopExpressions = ExpressionAssert.AsBlock(doWhileStatement.Body);
            Assert.Single(loopExpressions);
        }

        [Fact]
        public void ShouldParse_DoWhile_WithBody_WithoutBraces()
        {
            // Arrange
            var unit = _fixture.Compile("do var x = true; while(true);");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var doWhileStatement = ExpressionAssert.AsDoWhileLoop(expression);
            ExpressionAssert.Constant(doWhileStatement.Condition, true);
            ExpressionAssert.AsBinaryAssign(doWhileStatement.Body);
        }

        [Fact]
        public void ShouldParse_For_WithEmptyBody()
        {
            // Arrange
            var unit = _fixture.Compile("for (int i = 0; i < 10; i++) { }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var forStatement = ExpressionAssert.AsForLoop(expression);
            ExpressionAssert.AsBinaryAssign(forStatement.Initializer);
            ExpressionAssert.AsBinary(forStatement.Condition, ExpressionType.LessThan);
            ExpressionAssert.AsUnary(forStatement.Incrementator, ExpressionType.PostIncrementAssign);
            var loopExpressions = ExpressionAssert.AsBlock(forStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_For_WithEmptyBody_WithOuterScopeVariable()
        {
            // Arrange
            var unit = _fixture.Compile("int i; for (i = 0; i < 10; i++) { }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var forStatement = ExpressionAssert.AsForLoop(expressions[1]);
            ExpressionAssert.AsBinaryAssign(forStatement.Initializer);
            ExpressionAssert.AsBinary(forStatement.Condition, ExpressionType.LessThan);
            ExpressionAssert.AsUnary(forStatement.Incrementator, ExpressionType.PostIncrementAssign);
            var loopExpressions = ExpressionAssert.AsBlock(forStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_For_WithBody()
        {
            // Arrange
            var unit = _fixture.Compile("for (int i = 0; i < 10; i++) { var x = true; }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var forStatement = ExpressionAssert.AsForLoop(expression);
            ExpressionAssert.AsBinaryAssign(forStatement.Initializer);
            ExpressionAssert.AsBinary(forStatement.Condition, ExpressionType.LessThan);
            ExpressionAssert.AsUnary(forStatement.Incrementator, ExpressionType.PostIncrementAssign);
            var expressions = ExpressionAssert.AsBlock(forStatement.Body);
            Assert.Single(expressions);
        }

        [Fact]
        public void ShouldParse_For_WithBody_WithoutBraces()
        {
            // Arrange
            var unit = _fixture.Compile("for (int i = 0; i < 10; i++) var x = true;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var forStatement = ExpressionAssert.AsForLoop(expression);
            ExpressionAssert.AsBinaryAssign(forStatement.Initializer);
            ExpressionAssert.AsBinary(forStatement.Condition, ExpressionType.LessThan);
            ExpressionAssert.AsUnary(forStatement.Incrementator, ExpressionType.PostIncrementAssign);
            ExpressionAssert.AsBinaryAssign(forStatement.Body);
        }

        [Fact]
        public void ShouldParse_Foreach_WithEmptyBody()
        {
            // Arrange
            var unit = _fixture.Compile("foreach (int i in new List<int>()) { }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.New(foreachStatement.Collection, typeof(List<int>), Enumerable.Empty<Type>());
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            var loopExpressions = ExpressionAssert.AsBlock(foreachStatement.Body);
            Assert.Empty(loopExpressions);
        }


        [Fact]
        public void ShouldParse_Foreach_WithVar_WithGenericCollection()
        {
            // Arrange
            var unit = _fixture.Compile("foreach (var i in new List<int>()) { }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.New(foreachStatement.Collection, typeof(List<int>), Enumerable.Empty<Type>());
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            var loopExpressions = ExpressionAssert.AsBlock(foreachStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_Foreach_WithVar_WithArrayCollection()
        {
            // Arrange
            var unit = _fixture.Compile("foreach (var i in new int[3]) { }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.AsNewArrayBounds(foreachStatement.Collection, typeof(int[]));
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            var loopExpressions = ExpressionAssert.AsBlock(foreachStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_Foreach_WithBody()
        {
            // Arrange
            var unit = _fixture.Compile("foreach (int i in new List<int>()) { var x = true; }");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.New(foreachStatement.Collection, typeof(List<int>), Enumerable.Empty<Type>());
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            var loopExpressions = ExpressionAssert.AsBlock(foreachStatement.Body);
            Assert.Single(loopExpressions);
        }

        [Fact]
        public void ShouldParse_Foreach_WithBody_WithoutBraces()
        {
            // Arrange
            var unit = _fixture.Compile("foreach (int i in new List<int>()) var x = true;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.New(foreachStatement.Collection, typeof(List<int>), Enumerable.Empty<Type>());
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            ExpressionAssert.AsBinaryAssign(foreachStatement.Body);
        }
    }
}
