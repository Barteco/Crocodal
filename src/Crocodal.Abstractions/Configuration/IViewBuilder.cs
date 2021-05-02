namespace Crocodal
{
    public interface IViewBuilder<TView> : IObjectBuilder<IViewBuilder<TView>>
    {
        IViewBuilder<TView> AsMaterialized();
        IViewBuilder<TView> WithDistribution(string distribution);
    }
}