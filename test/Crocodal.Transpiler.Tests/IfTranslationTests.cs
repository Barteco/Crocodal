using Crocodal.Transpiler.Tests.Core;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class IfTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_If_WithEmptyBody()
        {
            var unit = Compiler.Compile("if(true) { }");

            var expression = _translator.Translate(unit);

            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Empty(trueExpressions);
            ExpressionAssert.Default(ifStatement.IfFalse);
        }

        [Fact]
        public void ShouldParse_If_WithBody()
        {
            var unit = Compiler.Compile("if(true) { var x = true; }");

            var expression = _translator.Translate(unit);

            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            ExpressionAssert.Default(ifStatement.IfFalse);
        }

        [Fact]
        public void ShouldParse_If_WithEmptyElse()
        {
            var unit = Compiler.Compile("if(true) { var x = true; } else { }");

            var expression = _translator.Translate(unit);

            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            var falseExpressions = ExpressionAssert.AsBlock(ifStatement.IfFalse);
            Assert.Empty(falseExpressions);
        }

        [Fact]
        public void ShouldParse_If_WithElse()
        {
            var unit = Compiler.Compile("if(true) { var x = true; } else { var y = false; }");

            var expression = _translator.Translate(unit);

            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            var falseExpressions = ExpressionAssert.AsBlock(ifStatement.IfFalse);
            Assert.Single(falseExpressions);
        }

        [Fact]
        public void ShouldParse_If_WithElseIf()
        {
            var unit = Compiler.Compile("if(true) { var x = true; } else if (false) { var y = false; }");

            var expression = _translator.Translate(unit);

            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            var elseIfStatement = ExpressionAssert.AsConditional(ifStatement.IfFalse);
            ExpressionAssert.Constant(elseIfStatement.Test, false);
            var elseTrueExpressions = ExpressionAssert.AsBlock(elseIfStatement.IfTrue);
            Assert.Single(elseTrueExpressions);
            ExpressionAssert.Default(elseIfStatement.IfFalse);
        }

        [Fact]
        public void ShouldParse_If_WithElseIf_WithElse()
        {
            var unit = Compiler.Compile("if(true) { var x = true; } else if (false) { var y = false; } else { var z = false; }");

            var expression = _translator.Translate(unit);

            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            var trueExpressions = ExpressionAssert.AsBlock(ifStatement.IfTrue);
            Assert.Single(trueExpressions);
            var elseIfStatement = ExpressionAssert.AsConditional(ifStatement.IfFalse);
            ExpressionAssert.Constant(elseIfStatement.Test, false);
            var elseTrueExpressions = ExpressionAssert.AsBlock(elseIfStatement.IfTrue);
            Assert.Single(elseTrueExpressions);
            var elseFalseExpressions = ExpressionAssert.AsBlock(elseIfStatement.IfFalse);
            Assert.Single(elseFalseExpressions);
        }

        [Fact]
        public void ShouldParse_If_WithElse_WithoutBraces()
        {
            var unit = Compiler.Compile("if(true) var x = true; else var y = false;");

            var expression = _translator.Translate(unit);

            var ifStatement = ExpressionAssert.AsConditional(expression);
            ExpressionAssert.Constant(ifStatement.Test, true);
            ExpressionAssert.AsBinaryAssign(ifStatement.IfTrue);
            ExpressionAssert.AsBinaryAssign(ifStatement.IfFalse);
        }

        [Fact]
        public void ShouldParse_TernaryConditionalStatement()
        {
            var unit = Compiler.Compile("var x = true ? true : false;");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var ternaryStatement = ExpressionAssert.AsConditional(binaryExpression.Right);
            ExpressionAssert.Constant(ternaryStatement.Test, true);
            ExpressionAssert.Constant(ternaryStatement.IfTrue, true);
            ExpressionAssert.Constant(ternaryStatement.IfFalse, false);
        }
    }
}
