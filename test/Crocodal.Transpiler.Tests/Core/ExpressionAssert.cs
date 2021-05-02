using Crocodal.Transpiler.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace Crocodal.Transpiler.Tests.Core
{
    public static class ExpressionAssert
    {
        public static TExpression As<TExpression>(Expression expression, ExpressionType expectedNodeType) where TExpression : Expression
        {
            Assert.IsAssignableFrom<TExpression>(expression);
            Assert.Equal(expectedNodeType, expression.NodeType);

            return (TExpression)expression;
        }

        public static BinaryExpression AsBinary(Expression expression, ExpressionType expectedNodeType)
        {
            return As<BinaryExpression>(expression, expectedNodeType);
        }

        public static BinaryExpression AsBinaryAssign(Expression expression)
        {
            return AsBinary(expression, ExpressionType.Assign);
        }

        public static TypeBinaryExpression AsBinaryTypeCheck(Expression expression, Type checkType)
        {
            var binary = As<TypeBinaryExpression>(expression, ExpressionType.TypeIs);
            Assert.Equal(checkType, binary.TypeOperand);
            return binary;
        }

        public static Expression[] AsBlock(Expression expression)
        {
            return As<BlockExpression>(expression, ExpressionType.Block).Expressions.ToArray();
        }

        public static ConditionalExpression AsConditional(Expression expression)
        {
            return As<ConditionalExpression>(expression, ExpressionType.Conditional);
        }

        public static UnaryExpression AsConvert(Expression expression, Type targetType)
        {
            var unary = As<UnaryExpression>(expression, ExpressionType.Convert);
            Assert.Equal(targetType, unary.Type);
            return unary;
        }

        public static UnaryExpression AsConvertChecked(Expression expression, Type targetType)
        {
            var unary = As<UnaryExpression>(expression, ExpressionType.ConvertChecked);
            Assert.Equal(targetType, unary.Type);
            return unary;
        }

        public static DoWhileLoopExpression AsDoWhileLoop(Expression expression)
        {
            return As<DoWhileLoopExpression>(expression, ExpressionType.Loop);
        }

        public static ForeachLoopExpression AsForeachLoop(Expression expression)
        {
            return As<ForeachLoopExpression>(expression, ExpressionType.Loop);
        }

        public static ForLoopExpression AsForLoop(Expression expression)
        {
            return As<ForLoopExpression>(expression, ExpressionType.Loop);
        }

        public static IndexExpression AsIndexer(Expression expression)
        {
            return As<IndexExpression>(expression, ExpressionType.Index);
        }

        public static MemberExpression AsMember(Expression expression)
        {
            return As<MemberExpression>(expression, ExpressionType.MemberAccess);
        }

        public static MethodCallExpression AsMethodCall(Expression expression)
        {
            return As<MethodCallExpression>(expression, ExpressionType.Call);
        }

        public static Expression[] AsMultiline(Expression expression)
        {
            return As<MultilineExpression>(expression, ExpressionType.Block).Expressions.ToArray();
        }

        public static NewArrayExpression AsNewArrayBounds(Expression expression, Type arrayType)
        {
            var newArray = As<NewArrayExpression>(expression, ExpressionType.NewArrayBounds);
            Assert.Equal(arrayType, newArray.Type);
            return newArray;
        }

        public static NewArrayExpression AsNewArrayInit(Expression expression, Type arrayType, int initializersCount)
        {
            var newArray = As<NewArrayExpression>(expression, ExpressionType.NewArrayInit);
            Assert.Equal(arrayType, newArray.Type);
            Assert.Equal(initializersCount, newArray.Expressions.Count);
            return newArray;
        }

        public static TupleExpression AsTuple(Expression expression)
        {
            return As<TupleExpression>(expression, ExpressionType.Parameter);
        }

        public static UnaryExpression AsUnary(Expression expression, ExpressionType expectedNodeType)
        {
            return As<UnaryExpression>(expression, expectedNodeType);
        }

        public static WhileLoopExpression AsWhileLoop(Expression expression)
        {
            return As<WhileLoopExpression>(expression, ExpressionType.Loop);
        }

        public static void ArrayOfConstants(IEnumerable<Expression> expressions, params object[] values)
        {
            Assert.Equal(values.Length, expressions.Count());
            foreach (var (expression, value) in expressions.Zip(values))
            {
                Assert.IsAssignableFrom<ConstantExpression>(expression);
                Assert.Equal(value, ((ConstantExpression)expression).Value);
            }
        }

        public static void Constant(Expression expression, object value)
        {
            Assert.IsAssignableFrom<ConstantExpression>(expression);
            Assert.Equal(value, ((ConstantExpression)expression).Value);
        }

        public static void Declaration(Expression expression, Type parameterType, string parameterName)
        {
            Assert.IsAssignableFrom<DeclarationExpression>(expression);
            Assert.Equal(parameterType, ((DeclarationExpression)expression).Type);
            Assert.Equal(parameterName, ((DeclarationExpression)expression).Parameter.Name);
        }

        public static void Default(Expression expression)
        {
            Assert.IsAssignableFrom<DefaultExpression>(expression);
        }

        public static void New(Expression expression, Type constructorType, IEnumerable<Type> argumentTypes)
        {
            Assert.IsAssignableFrom<NewExpression>(expression);
            Assert.Equal(constructorType, ((NewExpression)expression).Type);
            Assert.Equal(argumentTypes, ((NewExpression)expression).Arguments.Select(e => e.Type));
        }

        public static void Null(Expression expression)
        {
            Assert.Null(((ConstantExpression)expression).Value);
        }

        public static void Parameter(Expression expression, Type parameterType, string parameterName)
        {
            Assert.IsAssignableFrom<ParameterExpression>(expression);
            Assert.Equal(parameterType, ((ParameterExpression)expression).Type);
            Assert.Equal(parameterName, ((ParameterExpression)expression).Name);
        }
    }
}
