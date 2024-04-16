using EDA.Router.Model.ConflictResolvers;
using EDA.Router.Model.Rules;

namespace EDA.Router.Model
{
    public class ContentBasedRouter<T> : IContentBasedRouter<T>
    {
        private readonly RoutingTable<T> routingTable;
        private readonly IConflictResolvingStrategy<T>? conflictResolver;

        public ContentBasedRouter(RoutingTable<T> routingTable,IConflictResolvingStrategy<T>? conflictResolver)
        {
            this.routingTable = routingTable;
            this.conflictResolver = conflictResolver;
        }
        public string? FindDestinationFor(T message)
        {
            var destinations=routingTable.FindDestinationForMessage(message);
            if(ConflictDetected(destinations))
            {
                return conflictResolver?.Resolve(message, destinations);
            }
            return destinations.FirstOrDefault();
        }

        private bool ConflictDetected(List<string> destinations)
        {
            return destinations.Count > 1;
        }
    }
}
