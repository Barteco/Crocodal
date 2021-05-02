using Crocodal.Transpiler.Tests.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Xunit;

namespace Crocodal.Transpiler.Tests
{

    public class MemberAccessTranslationTests
    {
        private readonly StatementTranslator _translator = new StatementTranslator();

        [Fact]
        public void ShouldParse_InstancePropertyAccess()
        {
            var unit = Compiler.Compile("DateTime x; var y = x.Ticks;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            var member = ExpressionAssert.AsMember(binaryExpression.Right);
            ExpressionAssert.Parameter(member.Expression, typeof(DateTime), "x");
            Assert.Equal("Ticks", member.Member.Name);
            Assert.Equal(typeof(DateTime), member.Member.DeclaringType);
        }

        [Fact]
        public void ShouldParse_ChainedInstancePropertyAccess()
        {
            var unit = Compiler.Compile("DateTime x; var y = x.Date.Ticks;");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            var member = ExpressionAssert.AsMember(binaryExpression.Right);
            var chainedMember = ExpressionAssert.AsMember(member.Expression);
            Assert.Equal("Date", chainedMember.Member.Name);
            Assert.Equal(typeof(DateTime), chainedMember.Member.DeclaringType);
            Assert.Equal("Ticks", member.Member.Name);
            Assert.Equal(typeof(DateTime), member.Member.DeclaringType);
        }

        [Fact]
        public void ShouldParse_StaticPropertyAccess()
        {
            var unit = Compiler.Compile("var x = DateTime.Now;");

            var expression = _translator.Translate(unit);

            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var member = ExpressionAssert.AsMember(binaryExpression.Right);
            Assert.Null(member.Expression);
            Assert.Equal("Now", member.Member.Name);
            Assert.Equal(typeof(DateTime), member.Member.DeclaringType);
        }

        [Fact]
        public void ShouldParse_ArrayAccess()
        {
            var unit = Compiler.Compile("var x = new int[3]; var y = x[0]");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            var indexer = ExpressionAssert.AsIndexer(binaryExpression.Right);
            ExpressionAssert.Parameter(indexer.Object, typeof(int[]), "x");
            Assert.Single(indexer.Arguments);
            ExpressionAssert.Constant(indexer.Arguments[0], 0);
        }

        [Fact]
        public void ShouldParse_IndexerAccess()
        {
            var unit = Compiler.Compile(@"var x = new Dictionary<string, string>(); var y = x[""key""]");

            var expression = _translator.Translate(unit);

            var expressions = ExpressionAssert.AsMultiline(expression);
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            var indexer = ExpressionAssert.AsIndexer(binaryExpression.Right);
            ExpressionAssert.Parameter(indexer.Object, typeof(Dictionary<string, string>), "x");
            Assert.Single(indexer.Arguments);
            ExpressionAssert.Constant(indexer.Arguments[0], "key");
        }
    }
}
