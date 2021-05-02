using Crocodal.Transpiler.Tests.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class LoopTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_While_WithEmptyBody()
        {
            var unit = Compiler.Compile("while(true) { }");

            var expression = _translator.Translate(unit);

            var whileStatement = ExpressionAssert.AsWhileLoop(expression);
            ExpressionAssert.Constant(whileStatement.Condition, true);
            var loopExpressions = ExpressionAssert.AsBlock(whileStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_While_WithBody()
        {
            var unit = Compiler.Compile("while(true) { var x = true; }");

            var expression = _translator.Translate(unit);

            var whileStatement = ExpressionAssert.AsWhileLoop(expression);
            ExpressionAssert.Constant(whileStatement.Condition, true);
            var loopExpressions = ExpressionAssert.AsBlock(whileStatement.Body);
            Assert.Single(loopExpressions);
        }

        [Fact]
        public void ShouldParse_While_WithBody_WithoutBraces()
        {
            var unit = Compiler.Compile("while(true) var x = true;");

            var expression = _translator.Translate(unit);

            var whileStatement = ExpressionAssert.AsWhileLoop(expression);
            ExpressionAssert.Constant(whileStatement.Condition, true);
            ExpressionAssert.AsBinaryAssign(whileStatement.Body);
        }

        [Fact]
        public void ShouldParse_DoWhile_WithEmptyBody()
        {
            var unit = Compiler.Compile("do { } while(true);");

            var expression = _translator.Translate(unit);

            var doWhileStatement = ExpressionAssert.AsDoWhileLoop(expression);
            ExpressionAssert.Constant(doWhileStatement.Condition, true);
            var loopExpressions = ExpressionAssert.AsBlock(doWhileStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_DoWhile_WithBody()
        {
            var unit = Compiler.Compile("do { var x = true; } while(true);");

            var expression = _translator.Translate(unit);

            var doWhileStatement = ExpressionAssert.AsDoWhileLoop(expression);
            ExpressionAssert.Constant(doWhileStatement.Condition, true);
            var loopExpressions = ExpressionAssert.AsBlock(doWhileStatement.Body);
            Assert.Single(loopExpressions);
        }

        [Fact]
        public void ShouldParse_DoWhile_WithBody_WithoutBraces()
        {
            var unit = Compiler.Compile("do var x = true; while(true);");

            var expression = _translator.Translate(unit);

            var doWhileStatement = ExpressionAssert.AsDoWhileLoop(expression);
            ExpressionAssert.Constant(doWhileStatement.Condition, true);
            ExpressionAssert.AsBinaryAssign(doWhileStatement.Body);
        }

        [Fact]
        public void ShouldParse_For_WithEmptyBody()
        {
            var unit = Compiler.Compile("for (int i = 0; i < 10; i++) { }");

            var expression = _translator.Translate(unit);

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
            var unit = Compiler.Compile("int i; for (i = 0; i < 10; i++) { }");

            var expression = _translator.Translate(unit);

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
            var unit = Compiler.Compile("for (int i = 0; i < 10; i++) { var x = true; }");

            var expression = _translator.Translate(unit);

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
            var unit = Compiler.Compile("for (int i = 0; i < 10; i++) var x = true;");

            var expression = _translator.Translate(unit);

            var forStatement = ExpressionAssert.AsForLoop(expression);
            ExpressionAssert.AsBinaryAssign(forStatement.Initializer);
            ExpressionAssert.AsBinary(forStatement.Condition, ExpressionType.LessThan);
            ExpressionAssert.AsUnary(forStatement.Incrementator, ExpressionType.PostIncrementAssign);
            ExpressionAssert.AsBinaryAssign(forStatement.Body);
        }

        [Fact]
        public void ShouldParse_Foreach_WithEmptyBody()
        {
            var unit = Compiler.Compile("foreach (int i in new List<int>()) { }");

            var expression = _translator.Translate(unit);

            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.New(foreachStatement.Collection, typeof(List<int>), Enumerable.Empty<Type>());
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            var loopExpressions = ExpressionAssert.AsBlock(foreachStatement.Body);
            Assert.Empty(loopExpressions);
        }


        [Fact]
        public void ShouldParse_Foreach_WithVar_WithGenericCollection()
        {
            var unit = Compiler.Compile("foreach (var i in new List<int>()) { }");

            var expression = _translator.Translate(unit);

            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.New(foreachStatement.Collection, typeof(List<int>), Enumerable.Empty<Type>());
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            var loopExpressions = ExpressionAssert.AsBlock(foreachStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_Foreach_WithVar_WithArrayCollection()
        {
            var unit = Compiler.Compile("foreach (var i in new int[3]) { }");

            var expression = _translator.Translate(unit);

            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.AsNewArrayBounds(foreachStatement.Collection, typeof(int[]));
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            var loopExpressions = ExpressionAssert.AsBlock(foreachStatement.Body);
            Assert.Empty(loopExpressions);
        }

        [Fact]
        public void ShouldParse_Foreach_WithBody()
        {
            var unit = Compiler.Compile("foreach (int i in new List<int>()) { var x = true; }");

            var expression = _translator.Translate(unit);

            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.New(foreachStatement.Collection, typeof(List<int>), Enumerable.Empty<Type>());
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            var loopExpressions = ExpressionAssert.AsBlock(foreachStatement.Body);
            Assert.Single(loopExpressions);
        }

        [Fact]
        public void ShouldParse_Foreach_WithBody_WithoutBraces()
        {
            var unit = Compiler.Compile("foreach (int i in new List<int>()) var x = true;");

            var expression = _translator.Translate(unit);

            var foreachStatement = ExpressionAssert.AsForeachLoop(expression);
            ExpressionAssert.New(foreachStatement.Collection, typeof(List<int>), Enumerable.Empty<Type>());
            ExpressionAssert.Parameter(foreachStatement.Variable, typeof(int), "i");
            ExpressionAssert.AsBinaryAssign(foreachStatement.Body);
        }
    }
}
