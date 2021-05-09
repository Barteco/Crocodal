namespace Crocodal
{
    public interface IViewConfiguration<TView>
    {
        void Configure(IViewBuilder<TView> builder);
    }
}