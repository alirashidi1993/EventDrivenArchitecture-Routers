namespace EDA.Router.Splitters.Composed
{
    public class ComposedSplitter<TInput>
    {
        private readonly List<Func<TInput, object>> splitterFunctions;

        public ComposedSplitter(List<Func<TInput, object>> splitterFunctions)
        {
            this.splitterFunctions = splitterFunctions;
        }

        public List<object> Split(TInput input)
        {
            return splitterFunctions
                .Select(f => f.Invoke(input))
                .ToList();
        }
    }
}
