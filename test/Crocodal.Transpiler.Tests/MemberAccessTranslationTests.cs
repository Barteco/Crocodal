using Crocodal.Transpiler.Tests.Core;
using Crocodal.Transpiler.Tests.Fixtures;
using System;
using System.Collections.Generic;
using Xunit;

namespace Crocodal.Transpiler.Tests
{
    public class MemberAccessTranslationTests : IClassFixture<CompilerFixture>
    {
        private readonly StatementTranslator _translator = new();
        private readonly CompilerFixture _fixture;

        public MemberAccessTranslationTests(CompilerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ShouldParse_InstancePropertyAccess()
        {
            // Arrange
            var unit = _fixture.Compile("DateTime x; var y = x.Ticks;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
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
            // Arrange
            var unit = _fixture.Compile("DateTime x; var y = x.Date.Ticks;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
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
            // Arrange
            var unit = _fixture.Compile("var x = DateTime.Now;");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expression);
            var member = ExpressionAssert.AsMember(binaryExpression.Right);
            Assert.Null(member.Expression);
            Assert.Equal("Now", member.Member.Name);
            Assert.Equal(typeof(DateTime), member.Member.DeclaringType);
        }

        [Fact]
        public void ShouldParse_ArrayAccess()
        {
            // Arrange
            var unit = _fixture.Compile("var x = new int[3]; var y = x[0]");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
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
            // Arrange
            var unit = _fixture.Compile(@"var x = new Dictionary<string, string>(); var y = x[""key""]");

            // Act
            var expression = _translator.Translate(unit);

            // Assert
            var expressions = ExpressionAssert.AsMultiline(expression);
            var binaryExpression = ExpressionAssert.AsBinaryAssign(expressions[1]);
            var indexer = ExpressionAssert.AsIndexer(binaryExpression.Right);
            ExpressionAssert.Parameter(indexer.Object, typeof(Dictionary<string, string>), "x");
            Assert.Single(indexer.Arguments);
            ExpressionAssert.Constant(indexer.Arguments[0], "key");
        }
    }
}
