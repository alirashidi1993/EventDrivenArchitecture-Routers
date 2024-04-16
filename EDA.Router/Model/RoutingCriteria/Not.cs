namespace EDA.Router.Model.RoutingCriteria
{
    public class Not<T> : Criteria<T>
    {
        private Criteria<T> criteria;

        public Not(Criteria<T> criteria)
        {
            this.criteria = criteria;
        }

        public override bool SatisfiedBy(T target)
        {
            return !criteria.SatisfiedBy(target);
        }
    }
}
