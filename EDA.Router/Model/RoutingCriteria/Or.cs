namespace EDA.Router.Model.RoutingCriteria
{
    public class Or<T> : Criteria<T>
    {
        private readonly ICriteria<T> left;
        private readonly ICriteria<T> right;

        public Or(ICriteria<T> left, ICriteria<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool SatisfiedBy(T target)
        {
            return right.SatisfiedBy(target) || left.SatisfiedBy(target);
        }
    }
}
