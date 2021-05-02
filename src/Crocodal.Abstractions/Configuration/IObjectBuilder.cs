namespace Crocodal
{
    public partial interface IObjectBuilder<TBuilder>
    {
        TBuilder SetSchema(string scheme);
        TBuilder SetName(string name);
    }
}