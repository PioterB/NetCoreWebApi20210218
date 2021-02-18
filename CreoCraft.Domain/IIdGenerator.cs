namespace CreoCraft.Domain
{
    public interface IIdGenerator<TKey>
    {
        TKey Next();
    }
}