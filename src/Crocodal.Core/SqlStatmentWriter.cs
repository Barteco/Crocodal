using Crocodal.Core.Statements;
using Crocodal.Core.Statements.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crocodal.Core
{
    public class SqlStatmentWriter
    {
        private StringBuilder _builder = new StringBuilder();
        private int _indentation;

        protected virtual string VariablePrefixSymbol => "@";

        public string Write(SqlExpression sqlExpression)
        {
            _builder.Clear();
            _indentation = 0;

            Visit(sqlExpression);

            return _builder.ToString();
        }

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

        protected string EscapeSql(string value)
        {
            // TODO: actually escape it
            return value;
        }

        protected virtual void Visit(SqlExpression expression)
        {
            switch (expression)
            {
                case ComplexStatement complexStatement:
                    Visit(complexStatement);
                    break;
                case DeclareVariableStatement declareVariableStatement:
                    Visit(declareVariableStatement);
                    break;
            }
        }

        protected virtual void Visit(ComplexStatement statement)
        {
            for (int i = 0; i < statement.Statements.Length; i++)
            {
                Visit(statement.Statements[i]);
                WriteLine();
            }
        }

        protected virtual void Visit(DeclareVariableStatement statement)
        {
            Write("DECLARE ");
            Visit(statement.Name);
            Write(' ');
            Visit(statement.Type);
            if (statement.Value != null)
            {
                Write(" = ");
                Visit(statement.Value);
            }
            Write(';');
        }

        protected virtual void Visit(VariableName statement)
        {
            Write(VariablePrefixSymbol);
            Write(statement.Value);
        }

        protected virtual void Visit(DatabaseType statement)
        {
            var map = new Dictionary<Type, Action<DatabaseType>> {
                { typeof(string), type => { Write("NVARCHAR("); Write(type.MaxLength?.ToString() ?? "MAX");  Write(')'); } },
                { typeof(int), _ => Write("INT") },
                { typeof(DateTime), _ => Write("DATE") },
            };

            if (statement.OverridenType != null)
            {
                Write(statement.OverridenType);
            }
            else if (map.ContainsKey(statement.ClrType))
            {
                map[statement.ClrType](statement);
            }
        }

        protected virtual void Visit(ScalarValue statement)
        {
            if (statement.Type.IsUtf8 == true)
            {
                Write('N');
            }
            if (statement.Type.IsStringType)
            {
                Write('\'');
            }
            Write(EscapeSql(statement.Value.ToString()));
            if (statement.Type.IsStringType)
            {
                Write('\'');
            }
        }

        protected virtual void Visit(EntityName statement)
        {
            if (statement.Schema != null)
            {
                Write('[');
                Write(statement.Schema);
                Write("].");
            }
            Write('[');
            Write(statement.Name);
            Write(']');
        }

        protected virtual void Visit(EntityColumnName statement)
        {
            Write('[');
            Write(statement.Name);
            Write(']');
        }

        protected virtual void Visit<TResult>(UnionStatement<TResult> statement)
        {
            Visit(statement.Left);
            WriteLine();
            WriteIndentation();
            Write("UNION");
            WriteLine();
            Visit(statement.Right);
            WriteLine();
        }

        protected virtual void Visit<TResult>(UnionAllStatement<TResult> statement)
        {
            Visit(statement.Left);
            WriteLine();
            WriteIndentation();
            Write("UNION ALL");
            WriteLine();
            Visit(statement.Right);
            WriteLine();
        }

        protected virtual void Visit<TResult>(QueryStatement<TResult> statement)
        {
            Visit(statement.WithStatements);
            Write("SELCT ");
            // .. columns
            if (true /* has from */)
            {
                WriteLine();
                Write("FROM ");
                // .. table name or subquery
            }
            // .. joins
            // .. wheres
            // .. group by
            // .. havings
            // .. ordering
        }

        protected virtual void Visit(WithStatement[] statements)
        {
            WriteIndentation();
            Write("WITH ");
            for (int i = 0; i < statements.Length; i++)
            {
                if (i > 0)
                {
                    WriteIndentation();
                }
                Visit(statements[i]);
                if (i < statements.Length - 1)
                {
                    Write(',');
                }
                WriteLine();
            }
        }

        protected virtual void Visit(WithStatement statement)
        {
            Visit(statement.Name);
            Write(" (");
            for (int i = 0; i < statement.Columns.Length; i++)
            {
                Visit(statement.Columns[i]);
                if (i < statement.Columns.Length - 1)
                {
                    Write(',');
                }
            }
            Write(") AS (");
            WriteLine();
            IncreaseIndentation();
            Visit(statement.Body);
            DecreaseIndentation();
            Write(")");
            WriteLine();
        }
    }
}
