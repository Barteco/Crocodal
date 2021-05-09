namespace Crocodal
{
    public partial interface IStoredProcedureBuilder : IObjectBuilder<IStoredProcedureBuilder>
    {
        IStoredProcedureBuilder WithHint(string hint);
    }
}