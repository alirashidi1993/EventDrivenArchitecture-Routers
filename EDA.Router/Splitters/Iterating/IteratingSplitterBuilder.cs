namespace EDA.Router.Splitters.Iterating
{
    public class IteratingSplitterBuilder<TInput,TOutput>
    {
        private Func<TInput, int> iteration;
        private Func<TInput, int, TOutput> converter;

        public IteratingSplitterBuilder<TInput,TOutput> SplitBasedOn(Func<TInput,int> iteration)
        {
            this.iteration = iteration;
            return this;
        }

        public IteratingSplitterBuilder<TInput, TOutput> UsingConverter(Func<TInput, int,TOutput> converter)
        {
            this.converter = converter;
            return this;
        }
        public IteratingSplitter<TInput,TOutput> Build()
        {
            return new IteratingSplitter<TInput, TOutput>(iteration, converter);
        }
    }
}
