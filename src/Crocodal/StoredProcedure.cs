using Crocodal.Statements;
using System.Collections.Generic;

namespace Crocodal
{
    public class StoredProcedure<TResult> : ExecuteStoredProcedureStatement<TResult>
    {
        public string Name { get; }
        public object Paramters { get; }

        public StoredProcedure(IDatabase database, string name, object paramters) : base(database)
        {
            Name = name;
            Paramters = paramters;
        }
    }
}
