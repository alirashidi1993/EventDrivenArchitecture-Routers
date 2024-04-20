using EDA.Router.Model.RoutingCriteria;

namespace EDA.Router.Model.Rules
{
    public class RoutingRule<T>
    {
        public ICriteria<T> Criteria { get; }
        public List<string> Destinations { get; }
        public RoutingRule(ICriteria<T> criteria, string[] destinations)
        {
            Criteria = criteria;
            Destinations = destinations.ToList();
        }

        public bool IsSatisfiedByCriteria(T message)
        {
            return Criteria.SatisfiedBy(message);
        }

    }
}
