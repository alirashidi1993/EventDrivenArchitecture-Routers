namespace EDA.Router.Model.RoutingCriteria
{
    public class And<T>:Criteria<T>
    {
        private readonly ICriteria<T> left;
        private readonly ICriteria<T> right;

        public And(ICriteria<T> left,ICriteria<T> right)
        {
            this.left = left;
            this.right = right;
        }

        public override bool SatisfiedBy(T target)
        {
            return right.SatisfiedBy(target) && left.SatisfiedBy(target);
        }
    }
}
