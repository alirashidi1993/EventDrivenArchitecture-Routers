namespace EDA.Router.Splitters.Composed
{
    public class ComposedSplitterBuilder<TInput>
    {
        private readonly List<Func<TInput, object>> splitters = new List<Func<TInput, object>>();
        public ComposedSplitterBuilder<TInput> SplitBy(Func<TInput,object> splitter)
        {
            splitters.Add(splitter);
            return this;
        }
        public ComposedSplitter<TInput> Build()
        {
            return new ComposedSplitter<TInput>(splitters);
        }
    }

    public static class CreateComposedSplitter
    {
        public static ComposedSplitterBuilder<TInput> WhichTakesInput<TInput>()
        {
            return new ComposedSplitterBuilder<TInput>();
        }
    }
}
