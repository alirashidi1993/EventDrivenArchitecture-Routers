namespace EDA.Router.Splitters.Iterating
{
    public static class CreateIteratingSplitter
    {
        public static IteratingSplitterInputBuilder Which()
        {
            return new IteratingSplitterInputBuilder();
        }
    }

    public class IteratingSplitterInputBuilder
    {
        public IteratingSplitterOutputBuilder<TInput> TakesInput<TInput>()
        {
            return new IteratingSplitterOutputBuilder<TInput>();
        }
    }

    public class IteratingSplitterOutputBuilder<TInput>
    {
        public IteratingSplitterBuilder<TInput, TOutput> Produces<TOutput>()
        {
            return new IteratingSplitterBuilder<TInput, TOutput>();
        }
    }
}
