namespace Crocodal
{
    public interface IView<TView>
    {
        void Configure(IViewBuilder<TView> builder);
    }
}