namespace EDA.Router.Aggregators
{
    public class InMemoryAggregateRepository
    {

    }
    public interface IAggregateRepository<TKey, T>
    {
        public Task AddOrUpdate(TKey key, T value);

        public Task<Maybe<T>> Find(TKey key);
    }
}
