namespace Crocodal
{
    public partial interface IProcedureBuilder : IObjectBuilder<IProcedureBuilder>
    {
        IProcedureBuilder WithHint(string hint);
    }
}