namespace Crocodal
{
    public class QueryOptionsBuilder
    {
        public QueryOptionsBuilder AsEditable() { return this; }
        public QueryOptionsBuilder WithComment(string comment) { return this; }
        public QueryOptionsBuilder WithHint(string hint) { return this; }
        public QueryOptionsBuilder MaxRecursion(int recursion) { return this; }
    }
}