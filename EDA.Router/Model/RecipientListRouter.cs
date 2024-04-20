using EDA.Router.Model.Rules;

namespace EDA.Router.Model
{
    public class RecipientListRouter<T> : IRecipientList<T>
    {
        private readonly RoutingTable<T> routingTable;

        public RecipientListRouter(RoutingTable<T> routingTable)
        {
            this.routingTable = routingTable;
        }

        public List<string> FindDestinationsFor(T message)
        {
            var destinations=routingTable.FindDestinationForMessage(message);
            return destinations;
        }
    }
}
