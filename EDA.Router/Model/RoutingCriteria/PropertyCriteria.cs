namespace EDA.Router.Model.RoutingCriteria
{
    public class PropertyCriteria<T> : Criteria<T>
    {
        private readonly Func<T, bool> accessor;

        public PropertyCriteria(Func<T,bool> accessor)
        {
            this.accessor = accessor;
        }
        public override bool SatisfiedBy(T target)
        {
            return accessor.Invoke(target);
        }
    }
}
