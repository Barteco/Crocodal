namespace Crocodal
{
    public interface IPrimaryKeyBuilder<TColumn>
    {
        IPrimaryKeyBuilder<TColumn> SetSequence<TSequence>();
        IPrimaryKeyBuilder<TColumn> SetConstraintName(string name);
    }
}
