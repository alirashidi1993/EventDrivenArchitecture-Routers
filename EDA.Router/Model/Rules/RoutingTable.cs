using EDA.Router.Model.Constants;

namespace EDA.Router.Model.Rules
{
    public class RoutingTable<T>
    {
        private List<RoutingRule<T>> rules;
        private string defaultDestination;

        public RoutingTable()
        {
            rules = new List<RoutingRule<T>>();
            defaultDestination = Channels.NullChannel;
        }

        public void AddRule(RoutingRule<T> rule)
        {
            rules.Add(rule);
        }
        public void SetDefaultDestination(string channelName)
        {
            defaultDestination = channelName;
        }
        public void SetDestination(string channelName)
        {
            defaultDestination = channelName;
        }

        public List<string> FindDestinationForMessage(T message)
        {
            return rules.Where(r=>r.IsSatisfiedByCriteria(message))
                .Select(r=>r.Destination)
                .DefaultIfEmpty(defaultDestination)
                .ToList();
        }
    }
}
