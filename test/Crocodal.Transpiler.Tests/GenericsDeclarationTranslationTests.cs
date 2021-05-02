using Crocodal.Transpiler.Tests.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class GenericsDeclarationTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithSingleParam()
        {
            var unit = Compiler.Compile("List<string> x;");

            var expression = _translator.Translate(unit);

            ExpressionAssert.Declaration(expression, typeof(List<string>), "x");
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithSingleParam_WithQualifiedName()
        {
            var unit = Compiler.Compile("System.Collections.Generic.List<string> x;");

            var expression = _translator.Translate(unit);

            ExpressionAssert.Declaration(expression, typeof(List<string>), "x");
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithSingleParam_WithInitializer()
        {
            var unit = Compiler.Compile("List<string> x = new List<string>();");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(List<string>), "x");
            ExpressionAssert.New(binaryExpression.Right, typeof(List<string>), Enumerable.Empty<Type>());
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithSingleParam_WithInitializer_WithQualifiedName()
        {
            var unit = Compiler.Compile("System.Collections.Generic.List<string> x = new System.Collections.Generic.List<string>();");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(List<string>), "x");
            ExpressionAssert.New(binaryExpression.Right, typeof(List<string>), Enumerable.Empty<Type>());
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithMultipleParams()
        {
            var unit = Compiler.Compile("Dictionary<string, string> x;");

            var expression = _translator.Translate(unit);

            ExpressionAssert.Declaration(expression, typeof(Dictionary<string, string>), "x");
        }

        [Fact]
        public void ShouldParse_GenericTypeDeclaration_WithMultipleParams_WithInitializer()
        {
            var unit = Compiler.Compile("Dictionary<string, string> x = new Dictionary<string, string>();");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            ExpressionAssert.Declaration(binaryExpression.Left, typeof(Dictionary<string, string>), "x");
            ExpressionAssert.New(binaryExpression.Right, typeof(Dictionary<string, string>), Enumerable.Empty<Type>());
        }
    }
}
