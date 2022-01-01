using Crocodal.Transpiler.Expressions;
using Crocodal.Transpiler.Helpers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Crocodal.Transpiler
{
    public class StatementTranslator
    {
        private readonly string[] _commonNamespaces = new string[]
        { 
            "System", 
            "System.Collections.Generic", 
            "System.Text" 
        };

        private readonly Dictionary<string, Type> _typeNameToTypeMap = new()
        {
            { "object", typeof(object) },
            { "char", typeof(char) },
            { "string", typeof(string) },
            { "bool", typeof(bool) },
            { "byte", typeof(byte) },
            { "sbyte", typeof(sbyte) },
            { "short", typeof(short) },
            { "ushort", typeof(ushort) },
            { "int", typeof(int) },
            { "uint", typeof(uint) },
            { "long", typeof(long) },
            { "ulong", typeof(ulong) },
            { "float", typeof(float) },
            { "double", typeof(double) },
            { "decimal", typeof(decimal) }
        };

        private Dictionary<SyntaxKind, ExpressionType> _syntaxKindToBinaryOperatorType = new Dictionary<SyntaxKind, ExpressionType>
        {
            { SyntaxKind.AddExpression, ExpressionType.Add },
            { SyntaxKind.SubtractExpression, ExpressionType.Subtract },
            { SyntaxKind.MultiplyExpression, ExpressionType.Multiply },
            { SyntaxKind.DivideExpression, ExpressionType.Divide },
            { SyntaxKind.ModuloExpression, ExpressionType.Modulo },
            { SyntaxKind.GreaterThanExpression, ExpressionType.GreaterThan },
            { SyntaxKind.GreaterThanOrEqualExpression, ExpressionType.GreaterThanOrEqual },
            { SyntaxKind.LessThanExpression, ExpressionType.LessThan },
            { SyntaxKind.LessThanOrEqualExpression, ExpressionType.LessThanOrEqual },
            { SyntaxKind.EqualsExpression, ExpressionType.Equal },
            { SyntaxKind.NotEqualsExpression, ExpressionType.NotEqual },
            { SyntaxKind.LogicalAndExpression, ExpressionType.AndAlso },
            { SyntaxKind.LogicalOrExpression, ExpressionType.OrElse }
        };

        private Dictionary<SyntaxKind, ExpressionType> _syntaxKindToUnaryOperatorType = new Dictionary<SyntaxKind, ExpressionType>
        {
            { SyntaxKind.UnaryMinusExpression, ExpressionType.Negate },
            { SyntaxKind.UnaryPlusExpression, ExpressionType.UnaryPlus },
            { SyntaxKind.LogicalNotExpression, ExpressionType.Not },
            { SyntaxKind.PostIncrementExpression, ExpressionType.PostIncrementAssign },
            { SyntaxKind.PreIncrementExpression, ExpressionType.PreIncrementAssign },
            { SyntaxKind.PostDecrementExpression, ExpressionType.PostDecrementAssign },
            { SyntaxKind.PreDecrementExpression, ExpressionType.PreDecrementAssign },
        };

        public Expression Translate(CSharpSyntaxNode node)
        {
            var context = CreateContext(node);
            return Translate(context, node);
        }

        private TranslationContext CreateContext(CSharpSyntaxNode node)
        {
            var compilation = CSharpCompilation.Create("Test").AddSyntaxTrees(node.SyntaxTree);
            var model = compilation.GetSemanticModel(node.SyntaxTree);
            return new TranslationContext(model);
        }

        private Expression Translate(TranslationContext context, CSharpSyntaxNode node)
        {
            switch (node)
            {
                case ArgumentSyntax argument:
                    {
                        return Translate(context, argument.Expression);
                    }
                case ArrayCreationExpressionSyntax arrayCreationExpression:
                    {
                        var type = GetExpressionType(context, arrayCreationExpression.Type).GetElementType();
                        var bounds = arrayCreationExpression.Type.RankSpecifiers.SelectMany(specifier => specifier.Sizes.Select(size => Translate(context, size)).Where(e => e != null)).ToArray();
                        if (arrayCreationExpression.Initializer != null)
                        {
                            var initializers = arrayCreationExpression.Initializer.Expressions.Select(initializer => Translate(context, initializer)).ToArray();
                            return Expression.NewArrayInit(type, initializers);
                        }
                        return Expression.NewArrayBounds(type, bounds);
                    }
                case AssignmentExpressionSyntax assignmentExpression:
                    {
                        var right = Translate(context, assignmentExpression.Right);
                        context.SetRightSideType(right.Type);
                        var left = Translate(context, assignmentExpression.Left);
                        context.SetRightSideType(null);
                        return Expression.Assign(left, right);
                    }
                case BinaryExpressionSyntax binaryExpression when binaryExpression.IsKind(SyntaxKind.AsExpression):
                    {
                        var castType = GetExpressionType(context, binaryExpression.Right);
                        var expression = Translate(context, binaryExpression.Left);
                        return Expression.Convert(expression, castType);
                    }
                case BinaryExpressionSyntax binaryExpression when binaryExpression.IsKind(SyntaxKind.IsExpression):
                    {
                        var checkType = GetExpressionType(context, binaryExpression.Right);
                        var expression = Translate(context, binaryExpression.Left);
                        return Expression.TypeIs(expression, checkType);
                    }
                case BinaryExpressionSyntax binaryExpression:
                    {
                        var left = Translate(context, binaryExpression.Left);
                        var right = Translate(context, binaryExpression.Right);
                        var type = MapBinarySyntaxKind(binaryExpression.Kind());
                        return Expression.MakeBinary(type, left, right);
                    }
                case BlockSyntax blockSyntax:
                    {
                        var expressions = blockSyntax.Statements.Select(expression => Translate(context, expression)).ToArray();
                        return Expression.Block(expressions);
                    }
                case CastExpressionSyntax castExpression:
                    {
                        var castType = GetExpressionType(context, castExpression.Type);
                        var expression = Translate(context, castExpression.Expression);
                        return Expression.ConvertChecked(expression, castType);
                    }
                case ConditionalExpressionSyntax conditionalExpression:
                    {
                        var condition = Translate(context, conditionalExpression.Condition);
                        var ifTrue = Translate(context, conditionalExpression.WhenTrue);
                        var ifFalse = Translate(context, conditionalExpression.WhenFalse);
                        return Expression.Condition(condition, ifTrue, ifFalse);
                    }
                case CompilationUnitSyntax compilationUnit:
                    {
                        var expressions = compilationUnit.Members.Select(expression => Translate(context, expression)).ToArray();
                        if (expressions.Length == 1)
                        {
                            return expressions[0];
                        }
                        return ExpressionBuilder.Multiline(expressions);
                    }
                case DeclarationExpressionSyntax declarationExpression:
                    {
                        var designation = Translate(context, declarationExpression.Designation);
                        var designationParameters = designation is ParameterExpression parameterExpression
                            ? new List<ParameterExpression> { parameterExpression }
                            : ((MultilineExpression)designation).Expressions.OfType<ParameterExpression>().ToList();

                        var type = !declarationExpression.Type.IsVar
                           ? GetExpressionType(context, declarationExpression.Type)
                           : context.GetVariableType(declarationExpression.Designation.ToString());

                        if (designationParameters.Count > 1)
                        {
                            var declarations = new List<DeclarationExpression>();

                            for (int i = 0; i < designationParameters.Count; i++)
                            {
                                var declarationType = type.IsGenericTupleType() ? type.GetGenericArguments()[i] : type;
                                var declaration = ExpressionBuilder.Declaration(declarationType, designationParameters[i].Name);
                                context.TrackVariable(designationParameters[i].Name, declarationType);
                                declarations.Add(declaration);
                            }

                            return ExpressionBuilder.Tuple(declarations.ToArray());
                        }
                        else
                        {
                            var declaration = ExpressionBuilder.Declaration(type, declarationExpression.Designation.ToString());
                            context.TrackVariable(declarationExpression.Designation.ToString(), type);
                            return declaration;
                        }
                    }
                case DoStatementSyntax whileStatement:
                    {
                        var condition = Translate(context, whileStatement.Condition);
                        var body = Translate(context, whileStatement.Statement);
                        return ExpressionBuilder.DoWhile(condition, body);
                    }
                case EqualsValueClauseSyntax equalsValueClause:
                    {
                        return Translate(context, equalsValueClause.Value);
                    }
                case ElementAccessExpressionSyntax elementAccessExpression:
                    {
                        var instance = Translate(context, elementAccessExpression.Expression);
                        var arguments = elementAccessExpression.ArgumentList.Arguments.Select(argument => Translate(context, argument)).ToArray();
                        var argumentTypes = arguments.Select(e => e.Type).ToArray();
                        var indexer = instance.Type.GetProperty("Item", argumentTypes);
                        return Expression.MakeIndex(instance, indexer, arguments);
                    }
                case ExpressionStatementSyntax expressionStatement:
                    {
                        return Translate(context, expressionStatement.Expression);
                    }
                case FieldDeclarationSyntax fieldDeclaration:
                    {
                        return Translate(context, fieldDeclaration.Declaration);
                    }
                case ForEachStatementSyntax foreachStatement:
                    {
                        var collection = Translate(context, foreachStatement.Expression);
                        var type = foreachStatement.Type.IsVar
                            ? GetCollectionElementType(collection.Type)
                            : GetExpressionType(context, foreachStatement.Type);
                        var variable = Expression.Variable(type, foreachStatement.Identifier.Text);
                        var body = Translate(context, foreachStatement.Statement);
                        return ExpressionBuilder.Foreach(variable, collection, body);
                    }
                case ForStatementSyntax forStatement:
                    {
                        if (forStatement.Initializers.Count > 1)
                            throw new UnsupportedNodeException("Only single initializer is supported in for loop");

                        if (forStatement.Incrementors.Count != 1)
                            throw new UnsupportedNodeException("Only single incrementator is supported in for loop");

                        var initializer = forStatement.Declaration != null
                            ? Translate(context, forStatement.Declaration)
                            : Translate(context, forStatement.Initializers.First());

                        var condition = Translate(context, forStatement.Condition);
                        var incrementator = Translate(context, forStatement.Incrementors.First());
                        var body = Translate(context, forStatement.Statement);
                        return ExpressionBuilder.For(initializer, condition, incrementator, body);
                    }
                case GlobalStatementSyntax globalStatement:
                    {
                        return Translate(context, globalStatement.Statement);
                    }
                case IdentifierNameSyntax identifierName:
                    {
                        var type = GetExpressionType(context, identifierName);
                        return Expression.Parameter(type, identifierName.Identifier.Text);
                    }
                case IfStatementSyntax ifStatement when ifStatement.Else == null:
                    {
                        var condition = Translate(context, ifStatement.Condition);
                        var ifTrue = Translate(context, ifStatement.Statement);
                        return Expression.IfThen(condition, ifTrue);
                    }
                case IfStatementSyntax ifStatement when ifStatement.Else != null:
                    {
                        var condition = Translate(context, ifStatement.Condition);
                        var ifTrue = Translate(context, ifStatement.Statement);
                        var ifFalse = Translate(context, ifStatement.Else.Statement);
                        return Expression.IfThenElse(condition, ifTrue, ifFalse);
                    }
                case InitializerExpressionSyntax initializerExpression when initializerExpression.IsKind(SyntaxKind.ArrayInitializerExpression):
                    {
                        var initializers = initializerExpression.Expressions.Select(expression => Translate(context, expression)).ToArray();
                        var commonType = initializers.Select(e => e.Type).Distinct().SingleOrDefault() ?? throw new UnsupportedNodeException("All initializer expressions must be of the same type");
                        return Expression.NewArrayInit(commonType, initializers);
                    }
                case InvocationExpressionSyntax invocationExpression when invocationExpression.Expression is MemberAccessExpressionSyntax memberAccessExpression:
                    {
                        var arguments = invocationExpression.ArgumentList.Arguments.Select(e => Translate(context, e)).ToArray();
                        var argumentTypes = arguments.Select(e => e.Type).ToArray();
                        var instance = Translate(context, memberAccessExpression.Expression);
                        var methodInfo = instance.Type.GetMethod(memberAccessExpression.Name.ToString(), argumentTypes);
                        return methodInfo.IsStatic
                            ? Expression.Call(methodInfo, arguments)
                            : Expression.Call(instance, methodInfo, arguments);
                    }
                case LiteralExpressionSyntax literalExpression:
                    {
                        return Expression.Constant(literalExpression.Token.Value);
                    }
                case LocalDeclarationStatementSyntax localDeclarationStatement:
                    {
                        return Translate(context, localDeclarationStatement.Declaration);
                    }
                case MemberAccessExpressionSyntax memberAccessExpression:
                    {
                        var instance = Translate(context, memberAccessExpression.Expression);
                        var memberInfo = instance.Type.GetMember(memberAccessExpression.Name.ToString()).Single();
                        return memberInfo.IsStatic()
                            ? Expression.MakeMemberAccess(null, memberInfo)
                            : Expression.MakeMemberAccess(instance, memberInfo);
                    }
                case ObjectCreationExpressionSyntax objectCreationExpression:
                    {
                        var arguments = objectCreationExpression.ArgumentList.Arguments.Select(arg => Translate(context, arg));
                        var argumentTypes = arguments.Select(e => e.Type).ToArray();
                        var type = GetExpressionType(context, objectCreationExpression.Type);
                        var constructor = type.GetConstructor(argumentTypes);
                        return Expression.New(constructor, arguments);
                    }
                case OmittedArraySizeExpressionSyntax omittedArraySizeExpression:
                    {
                        return null;
                    }
                case ParenthesizedExpressionSyntax parenthesizedExpression:
                    {
                        return Translate(context, parenthesizedExpression.Expression);
                    }
                case PostfixUnaryExpressionSyntax postfixUnaryExpression:
                    {
                        var operand = Translate(context, postfixUnaryExpression.Operand);
                        var unaryType = MapUnarySyntaxKind(postfixUnaryExpression.Kind());
                        return Expression.MakeUnary(unaryType, operand, null);
                    }
                case PrefixUnaryExpressionSyntax prefixUnaryExpression:
                    {
                        var operand = Translate(context, prefixUnaryExpression.Operand);
                        var unaryType = MapUnarySyntaxKind(prefixUnaryExpression.Kind());
                        return Expression.MakeUnary(unaryType, operand, null);
                    }
                case SingleVariableDesignationSyntax singleVariableDesignation:
                    {
                        return Expression.Parameter(typeof(object), singleVariableDesignation.Identifier.Text);
                    }
                case ParenthesizedVariableDesignationSyntax parenthesizedVariableDesignation:
                    {
                        var expressions = parenthesizedVariableDesignation.Variables.Select(variable => Translate(context, variable)).ToArray();
                        return ExpressionBuilder.Multiline(expressions);
                    }
                case TupleExpressionSyntax tupleExpression:
                    {
                        var expressions = tupleExpression.Arguments.Select((expression, index) => Translate(context.WithIndex(index), expression)).ToArray();
                        context.ResetIndex();
                        return ExpressionBuilder.Tuple(expressions);
                    }
                case VariableDeclarationSyntax variableDeclaration:
                    {
                        var type = !variableDeclaration.Type.IsVar
                            ? GetExpressionType(context, variableDeclaration.Type)
                            : null;

                        var declarations = variableDeclaration.Variables.Select(declarator =>
                        {
                            var initializer = declarator.Initializer != null
                                ? Translate(context, declarator.Initializer)
                                : null;

                            var declaration = ExpressionBuilder.Declaration(type ?? initializer.Type, declarator.Identifier.Text);
                            context.TrackVariable(declaration.Parameter.Name, declaration.Type);

                            if (initializer != null)
                            {
                                if (!initializer.Type.IsAssignableFrom(declaration.Type))
                                {
                                    initializer = RewriteExpressionType(initializer, declaration.Type);
                                }

                                return (Expression)Expression.Assign(declaration, initializer);
                            }

                            return declaration;
                        });

                        return ExpressionBuilder.Multiline(declarations.ToArray());
                    }
                case WhileStatementSyntax whileStatement:
                    {
                        var condition = Translate(context, whileStatement.Condition);
                        var body = Translate(context, whileStatement.Statement);
                        return ExpressionBuilder.While(condition, body);
                    }
                default:
                    throw new UnsupportedNodeException($"Unsupported node '{node}' of type '{node.GetType().Name}'");
            }
        }


        private Type GetExpressionType(TranslationContext context, CSharpSyntaxNode expression)
        {
            switch (expression)
            {
                case ArrayTypeSyntax arrayType:
                    {
                        return GetExpressionType(context, arrayType.ElementType).MakeArrayType();
                    }
                case IdentifierNameSyntax identifierName:
                    {
                        return GetIdentifierType(context, identifierName, identifierName.Identifier.Text);
                    }
                case GenericNameSyntax genericName:
                    {
                        var typeName = BuildGenericTypeName(context, genericName);
                        return _commonNamespaces
                            .Select(ns => $"{ns}.{typeName}")
                            .Select(type => Type.GetType(type, false))
                            .FirstOrDefault(t => t != null) ?? throw new UnsupportedNodeException($"Type '{typeName}' not found");
                    }
                case NullableTypeSyntax nullableType:
                    {
                        var elementType = GetExpressionType(context, nullableType.ElementType);
                        return typeof(Nullable<>).MakeGenericType(elementType);
                    }
                case PredefinedTypeSyntax predefinedType:
                    {
                        return MapPredefinedType(predefinedType.Keyword.ValueText);
                    }
                case QualifiedNameSyntax qualifiedName:
                    {
                        var typeName = qualifiedName.Right is GenericNameSyntax genericName
                            ? $"{qualifiedName.Left}.{BuildGenericTypeName(context, genericName)}"
                            : $"{qualifiedName.Left}.{qualifiedName.Right.Identifier.Text}";
                        return Type.GetType(typeName) ?? throw new UnsupportedNodeException($"Type '{typeName}' not found");
                    }
                case SingleVariableDesignationSyntax singleVariableDesignation:
                    {
                        return GetIdentifierType(context, singleVariableDesignation, singleVariableDesignation.Identifier.Text);
                    }
                default:
                    {
                        throw new UnsupportedNodeException($"Unsupported node '{expression}'");
                    }
            }
        }

        private Type GetIdentifierType(TranslationContext context, CSharpSyntaxNode syntaxNode, string name)
        {
            var convertedType = context.Model.GetTypeInfo(syntaxNode).ConvertedType;

            if (convertedType is IArrayTypeSymbol arrayTypeSymbol)
            {
                return context.GetVariableType(name);
            }
            else if (convertedType is INamedTypeSymbol namedTypeSymbol)
            {
                if (namedTypeSymbol.Name == "var")
                {
                    return context.GetVariableType(name);
                }
                else if (namedTypeSymbol != null && !string.IsNullOrEmpty(namedTypeSymbol.Name))
                {
                    var symbolTypeName = BuildSymbolTypeName(namedTypeSymbol);
                    return Type.GetType(symbolTypeName, false) ?? throw new UnsupportedNodeException($"Type '{symbolTypeName}' not found");
                }
            }

            return _commonNamespaces
                .Select(ns => $"{ns}.{name}")
                .Select(type => Type.GetType(type, false))
                .FirstOrDefault(t => t != null) ?? throw new UnsupportedNodeException($"Type '{name}' not found");
        }

        private Type GetCollectionElementType(Type type)
        {
            if (type.IsArray)
                return type.GetElementType();

            if (type.IsGenericType)
                return type.GetGenericArguments().SingleOrDefault() ?? throw new UnsupportedNodeException("Cannot determine collection element type");

            return null;
        }

        private ExpressionType MapBinarySyntaxKind(SyntaxKind kind)
        {
            return _syntaxKindToBinaryOperatorType.ContainsKey(kind)
               ? _syntaxKindToBinaryOperatorType[kind]
               : throw new UnsupportedNodeException($"Unsupported binary operator of kind '{kind}'");
        }

        private ExpressionType MapUnarySyntaxKind(SyntaxKind kind)
        {
            return _syntaxKindToUnaryOperatorType.ContainsKey(kind)
               ? _syntaxKindToUnaryOperatorType[kind]
               : throw new UnsupportedNodeException($"Unsupported unary operator of kind '{kind}'");
        }

        private Type MapPredefinedType(string type)
        {
            return _typeNameToTypeMap.ContainsKey(type)
                ? _typeNameToTypeMap[type]
                : throw new UnsupportedNodeException($"Unsupported predefined type '{type}'");
        }

        private string BuildGenericTypeName(TranslationContext context, GenericNameSyntax genericName)
        {
            return $"{genericName.Identifier.Text}`{genericName.TypeArgumentList.Arguments.Count}[{string.Join(",", genericName.TypeArgumentList.Arguments.Select((argument, index) => GetExpressionType(context.WithIndex(index), argument)))}]";
        }

        private string BuildSymbolTypeName(INamedTypeSymbol type)
        {
            var typeName = type.IsGenericType
                ? $"{type.Name}`{type.TypeArguments.Length}[{string.Join(",", type.TypeArguments.Select(ta => BuildSymbolTypeName(ta as INamedTypeSymbol)))}]"
                : $"{type.Name}";

            if (!type.ContainingNamespace.IsGlobalNamespace)
            {
                return $"{type.ContainingNamespace.ToDisplayString()}.{typeName}";
            }

            return _commonNamespaces
                .Select(ns => $"{ns}.{typeName}")
                .Where(typeName => Type.GetType(typeName) != null)
                .FirstOrDefault() ?? throw new UnsupportedNodeException($"Type '{typeName}' not found");
        }

        private Expression RewriteExpressionType(Expression expression, Type targetType)
        {
            switch (expression)
            {
                case ConstantExpression constantExpression:
                    {
                        return Expression.Constant(constantExpression.Value, targetType);
                    }
                default:
                    {
                        throw new UnsupportedNodeException($"Cannot rewrite type of expression: '{expression}");
                    }
            }
        }
    }
}
