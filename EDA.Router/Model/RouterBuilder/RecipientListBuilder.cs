using EDA.Router.Model.ConflictResolvers;
using EDA.Router.Model.RoutingCriteria;
using EDA.Router.Model.Rules;

namespace EDA.Router.Model.RouterBuilder
{
    public class RecipientListBuilder<T> : IRouterConditionBuilder<T>, IRouterDestinationBuilder<T>
    {

        private RoutingTable<T> routingTable;
        private ICriteria<T> currentCriteria;
        private IConflictResolvingStrategy<T> conflictResolver;
        public RecipientListBuilder() 
        {
            routingTable = new RoutingTable<T>();
        }
        public ContentBasedRouter<T> Build()
        {
            return new ContentBasedRouter<T>(routingTable, conflictResolver);
        }

        public IRouterConditionBuilder<T> ResolveConflictsWith(IConflictResolvingStrategy<T> strategy)
        {
            conflictResolver = strategy;
            return this;
        }

        public IRouterConditionBuilder<T> RouteTo(string channelName)
        {
            var rule = new RoutingRule<T>(currentCriteria, channelName);
            routingTable.AddRule(rule);
            return this;
        }

        public IRouterDestinationBuilder<T> When(ICriteria<T> criteria)
        {
            currentCriteria = criteria;
            return this;
        }

        public IRouterDestinationBuilder<T> When(Func<T, bool> criteria)
        {
            currentCriteria=new PropertyCriteria<T>(criteria);
            return this;
        }

        public IRouterConditionBuilder<T> WhenNoCriteriaMatchesRouteTo(string channel)
        {
            routingTable.SetDefaultDestination(channel);
            return this;
        }
    }
}
