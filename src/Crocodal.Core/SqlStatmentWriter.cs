using Crocodal.Core.Expressions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Operator = System.Linq.Expressions.ExpressionType;

namespace Crocodal.Core
{
    public class SqlStatmentWriter
    {
        #region Members

        private readonly StringBuilder _builder = new();
        private int _indentation;

        private Dictionary<Operator, string> _binaryOperators = new()
        {
            [Operator.AndAlso] = "AND",
            [Operator.OrElse] = "OR",
            [Operator.Assign] = "=",
            [Operator.Equal] = "=",
            [Operator.NotEqual] = "<>",
            [Operator.GreaterThan] = ">",
            [Operator.GreaterThanOrEqual] = ">=",
            [Operator.LessThan] = "<",
            [Operator.LessThanOrEqual] = "<=",
            [Operator.Add] = "+",
            [Operator.Subtract] = "-",
            [Operator.Multiply] = "*",
            [Operator.Divide] = "/",
            [Operator.Modulo] = "%"
        };

        private readonly Dictionary<Operator, string> _unaryOperators = new()
        {
            [Operator.UnaryPlus] = "+",
            [Operator.Negate] = "-",
        };

        #endregion

        #region Public

        public string Write(ISqlExpression expression)
        {
            Visit(expression);
            return _builder.ToString();
        }

        #endregion

        #region Writing

        protected void Write(string value)
        {
            _builder.Append(value);
        }

        protected void Write(char value)
        {
            _builder.Append(value);
        }

        protected void WriteLine()
        {
            _builder.AppendLine();
        }

        protected void WriteIndentation()
        {
            for (int i = 0; i < _indentation; i++)
            {
                Write('\t');
            }
        }

        protected void IncreaseIndentation()
        {
            _indentation++;
        }

        protected void DecreaseIndentation()
        {
            _indentation--;
        }

        #endregion Writing

        #region Utilities

        protected string EscapeSql(string value)
        {
            // TODO: actually escape it
            return value;
        }

        #endregion

        #region Visitors

        #region Start

        protected virtual void Visit(ISqlExpression expression)
        {
            switch (expression)
            {
                case AliasExpression e: Visit(e); break;
                case BinaryExpression e: Visit(e); break;
                case ColumnListExpression e: Visit(e); break;
                case CustomDbTypeExpression e: Visit(e); break;
                case DateLiteralExpression e: Visit(e); break;
                case DateDbTypeExpression e: Visit(e); break;
                case DecimalDbTypeExpression e: Visit(e); break;
                case DecimalLiteralExpression e: Visit(e); break;
                case DoubleDbTypeExpression e: Visit(e); break;
                case DoubleLiteralExpression e: Visit(e); break;
                case ExecuteStoredProcedureExpression e: Visit(e); break;
                case FunctionCallExpression e: Visit(e); break;
                case IdentifierExpression e: Visit(e); break;
                case InsertIntoExpression e: Visit(e); break;
                case InsertIntoSelectExpression e: Visit(e); break;
                case IntDbTypeExpression e: Visit(e); break;
                case IntLiteralExpression e: Visit(e); break;
                case ListExpression e: Visit(e); break;
                case ComplexIdentifierExpression e: Visit(e); break;
                case MultilineExpression e: Visit(e); break;
                case SelectExpression e: Visit(e); break;
                case StringDbTypeExpression e: Visit(e); break;
                case StringLiteralExpression e: Visit(e); break;
                case TemporaryTableExpression e: Visit(e); break;
                case UnaryExpression e: Visit(e); break;
                case UnionAllExpression e: Visit(e); break;
                case UnionExpression e: Visit(e); break;
                case UpdateExpression e: Visit(e); break;
                case VariableDeclarationExpression e: Visit(e); break;
                case VariableExpression e: Visit(e); break;
                case VariableSetExpression e: Visit(e); break;
                default: throw new InvalidOperationException($"Expression of type {expression.GetType()} not supported");
            }
        }

        protected virtual void Visit(MultilineExpression expression)
        {
            for (int i = 0; i < expression.Children.Length; i++)
            {
                WriteIndentation();
                Visit(expression.Children[i]);
                WriteLine();
            }
        }

        #endregion

        #region Identifiers

        protected virtual void Visit(ComplexIdentifierExpression expression)
        {
            Visit(expression.Left);
            Write(".");
            Visit(expression.Right);
        }

        protected virtual void Visit(IdentifierExpression expression)
        {
            Write('[');
            Write(expression.Name);
            Write(']');
        }

        protected virtual void Visit(AliasExpression expression)
        {
            Visit(expression.Expression);
            Write(" AS ");
            Visit(expression.Alias);
        }

        protected virtual void Visit(VariableExpression expression)
        {
            Write("@");
            Write(expression.Name);
        }

        protected virtual void Visit(TemporaryTableExpression expression)
        {
            Write("#");
            Write(expression.Name);
        }

        #endregion

        #region Variables

        protected virtual void Visit(VariableDeclarationExpression expression)
        {
            Write("DECLARE ");
            Visit(expression.Variable);
            Write(' ');
            Visit(expression.Type);
        }

        protected virtual void Visit(VariableSetExpression expression)
        {
            Write("SET ");
            Visit(expression.Variable);
        }

        #endregion

        #region Binary/unary expressions

        protected virtual void Visit(BinaryExpression expression)
        {
            if (!_binaryOperators.ContainsKey(expression.Operator))
            {
                throw new InvalidOperationException($"Binary operator {expression.Operator} not supported");
            }

            var (wrapLeft, wrapRight) = DetermineParens(expression.Left, expression.Operator, expression.Right);

            Write(wrapLeft ? "(" : "");
            Visit(expression.Left);
            Write(wrapLeft ? ")" : "");
            Write(" ");
            Write(_binaryOperators[expression.Operator]);
            Write(" ");
            Write(wrapRight ? "(" : "");
            Visit(expression.Right);
            Write(wrapRight ? ")" : "");
        }

        private (bool, bool) DetermineParens(ISqlExpression left, Operator middleOp, ISqlExpression right)
        {
            var wrapOps = new List<Operator> { Operator.AndAlso, Operator.OrElse };
            var wrapOpsPairs = new Dictionary<Operator, Operator> { [Operator.AndAlso] = Operator.OrElse, [Operator.OrElse] = Operator.AndAlso };
            var leftOp = left is BinaryExpression bl && wrapOps.Contains(bl.Operator) ? bl.Operator : (Operator?)null;
            var rightOp = right is BinaryExpression br && wrapOps.Contains(br.Operator) ? br.Operator : (Operator?)null;
            var wrapLeft = leftOp.HasValue;
            var wrapRight = rightOp.HasValue;

            if (leftOp.HasValue && leftOp == middleOp && rightOp != wrapOpsPairs[leftOp.Value]) wrapLeft = false;
            if (rightOp.HasValue && rightOp == middleOp && leftOp != wrapOpsPairs[rightOp.Value]) wrapRight = false;

            return (wrapLeft, wrapRight);
        }

        protected virtual void Visit(UnaryExpression expression)
        {
            if (!_unaryOperators.ContainsKey(expression.Operator))
            {
                throw new InvalidOperationException($"Unary operator {expression.Operator} not supported");
            }

            Write(_unaryOperators[expression.Operator]);
            Visit(expression.Operand);
        }

        #endregion

        #region Database types

        protected virtual void Visit(CustomDbTypeExpression expression)
        {
            Write(expression.OverridenType);
        }

        protected virtual void Visit(IntDbTypeExpression expression)
        {
            Write("INT");
        }

        protected virtual void Visit(DoubleDbTypeExpression expression)
        {
            Write("FLOAT(53)");
        }

        protected virtual void Visit(DecimalDbTypeExpression expression)
        {
            Write("DECIMAL(");
            Write(expression.Precision.ToString());
            Write(", ");
            Write(expression.Scale.ToString());
            Write(')');
        }

        protected virtual void Visit(StringDbTypeExpression expression)
        {
            Write(expression.IsUnicode ? "N" : "");
            Write("VARCHAR(");
            Write(expression.MaxLength?.ToString() ?? "MAX");
            Write(')');
        }

        protected virtual void Visit(DateDbTypeExpression expression)
        {
            Write("DATETIME");
        }

        #endregion

        #region Literals

        protected virtual void Visit(IntLiteralExpression statement)
        {
            Write(statement.Value.ToString());
        }

        protected virtual void Visit(DoubleLiteralExpression statement)
        {
            Write(statement.Value.ToString(CultureInfo.InvariantCulture));
        }

        protected virtual void Visit(DecimalLiteralExpression statement)
        {
            Write(statement.Value.ToString(CultureInfo.InvariantCulture));
        }

        protected virtual void Visit(DateLiteralExpression statement)
        {
            Write('\'');
            Write(statement.Value.ToString("yyyy-MM-dd"));
            Write('\'');
        }

        protected virtual void Visit(StringLiteralExpression expression)
        {
            Write(expression.IsUnicode ? "N" : "");
            Write('\'');
            Write(EscapeSql(expression.Value));
            Write('\'');
        }

        #endregion

        #region Selects

        protected virtual void Visit(SelectExpression expression)
        {
            if (expression?.With?.Children?.Length > 0)
            {
                Visit(expression.With);
                WriteLine();
                WriteIndentation();
            }
            Write("SELECT ");
            Visit(expression.Columns);
            if (expression.From?.Children?.Length > 0)
            {
                WriteLine();
                WriteIndentation();
                Visit(expression.From);
            }

            // .. joins
            if (expression.Condition != null)
            {
                WriteLine();
                WriteIndentation();
                Write("WHERE ");
                Visit(expression.Condition);
            }
            // .. group by
            // .. havings
            // .. ordering
        }

        protected virtual void Visit(CteListExpression expression)
        {
            Write("WITH ");
            for (int i = 0; i < expression.Children.Length; i++)
            {
                if (i > 0)
                {
                    WriteIndentation();
                }
                Visit(expression.Children[i]);
                if (i < expression.Children.Length - 1)
                {
                    Write(",");
                    WriteLine();
                }
            }
        }

        protected virtual void Visit(CteExpression expression)
        {
            Visit(expression.Identifier);
            Write(" (");
            Visit(expression.Columns);
            Write(") AS (");
            WriteLine();
            IncreaseIndentation();
            Visit(expression.Definition);
            DecreaseIndentation();
            Write(")");
        }

        protected virtual void Visit(FromListExpression expression)
        {
            Write("FROM ");
            for (int i = 0; i < expression.Children.Length; i++)
            {
                if (expression.Children[i] is IQueryExpression)
                {
                    Write("(");
                    IncreaseIndentation();
                    Visit(expression.Children[i]);
                    DecreaseIndentation();
                    Write(")");
                }
                else
                {
                    Visit(expression.Children[i]);
                }

                if (i < expression.Children.Length - 1)
                {
                    Write(", ");
                }
            }
        }

        #endregion

        #region Unions

        protected virtual void Visit(UnionExpression statement)
        {
            Visit(statement.Left);
            WriteLine();
            WriteIndentation();
            Write("UNION");
            WriteLine();
            WriteIndentation();
            Visit(statement.Right);
        }

        protected virtual void Visit(UnionAllExpression statement)
        {
            Visit(statement.Left);
            WriteLine();
            WriteIndentation();
            Write("UNION ALL");
            WriteLine();
            WriteIndentation();
            Visit(statement.Right);
        }

        #endregion

        #region Inserts

        protected virtual void Visit(InsertIntoExpression expression)
        {
            Write("INSERT INTO ");
            Visit(expression.Table);
            Write(" (");
            Visit(expression.Columns);
            Write(")");
            WriteLine();
            WriteIndentation();
            Write("VALUES ");
            IncreaseIndentation();
            Visit(expression.Values);
            DecreaseIndentation();
        }

        protected virtual void Visit(InsertValuesListExpression expression)
        {
            for (int i = 0; i < expression.Children.Length; i++)
            {
                Write("(");
                Visit(expression.Children[i]);
                Write(")");
                if (i < expression.Children.Length - 1)
                {
                    Write(',');
                    WriteLine();
                    WriteIndentation();
                }
            }
        }

        protected virtual void Visit(InsertIntoSelectExpression expression)
        {
            Write("INSERT INTO ");
            Visit(expression.Table);
            WriteLine();
            WriteIndentation();
            Visit(expression.Select);
        }

        #endregion

        #region Updates

        protected virtual void Visit(UpdateExpression expression)
        {
            Write("UPDATE ");
            Visit(expression.Table);
            WriteLine();
            WriteIndentation();
            Write("SET ");
            Visit(expression.Values);
            if (expression.Condition != null)
            {
                WriteLine();
                WriteIndentation();
                Write("WHERE ");
                Visit(expression.Condition);
            }
        }

        protected virtual void Visit(UpdateSetValuesListExpression expression)
        {
            for (int i = 0; i < expression.Children.Length; i++)
            {
                Visit(expression.Children[i]);
                if (i < expression.Children.Length - 1)
                {
                    Write(", ");
                }
            }
        }

        #endregion

        #region Procedures

        protected virtual void Visit(ExecuteStoredProcedureExpression expression)
        {
            Write("EXEC ");
            Visit(expression.Procedure);
            if (expression.Parameters?.Children?.Length > 0)
            {
                Write(" ");
                Visit(expression.Parameters);
            }
        }

        #endregion

        #region Functions

        protected virtual void Visit(FunctionCallExpression expression)
        {
            Visit(expression.Function);
            Write("(");
            if (expression.Parameters?.Children?.Length > 0)
            {
                Visit(expression.Parameters);
            }
            Write(")");
        }

        #endregion

        #region Common

        protected virtual void Visit(ColumnListExpression expression)
        {
            Visit(expression.Children);
        }

        protected virtual void Visit(ListExpression expression)
        {
            for (int i = 0; i < expression.Children.Length; i++)
            {
                Visit(expression.Children[i]);
                if (i < expression.Children.Length - 1)
                {
                    Write(", ");
                }
            }
        }

        #endregion 

        #endregion Visitors
    }
}
