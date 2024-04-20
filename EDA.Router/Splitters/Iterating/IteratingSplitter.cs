namespace EDA.Router.Splitters.Iterating
{
    public class IteratingSplitter<Tinput, TOutput>
    {
        private readonly Func<Tinput, int> iteration;
        private readonly Func<Tinput, int, TOutput> converter;

        public IteratingSplitter(Func<Tinput, int> iteration, Func<Tinput, int, TOutput> converter)
        {
            this.iteration = iteration;
            this.converter = converter;
        }

        public List<TOutput> Split(Tinput input)
        {
            var outputList = new List<TOutput>();
            var loopCount = iteration.Invoke(input);

            for (int i = 0; i < loopCount; i++)
            {
                var item = converter(input, i);
                outputList.Add(item);
            }
            return outputList;
        }
    }
}
