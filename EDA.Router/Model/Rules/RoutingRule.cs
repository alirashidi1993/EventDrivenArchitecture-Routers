using EDA.Router.Model.RoutingCriteria;

namespace EDA.Router.Model.Rules
{
    public class RoutingRule<T>
    {
        public ICriteria<T> Criteria { get; }
        public string Destination { get; }
        public RoutingRule(ICriteria<T> criteria, string destination)
        {
            Criteria = criteria;
            Destination = destination;
        }

        public bool IsSatisfiedByCriteria(T message)
        {
            return Criteria.SatisfiedBy(message);
        }

    }
}
