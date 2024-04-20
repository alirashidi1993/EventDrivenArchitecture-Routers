using EDA.Router.Model.ConflictResolvers;
using EDA.Router.Model.RoutingCriteria;

namespace EDA.Router.Model.RouterBuilder
{
    public interface IRouterConditionBuilder<T>
    {
        IRouterConditionBuilder<T> ResolveConflictsWith(IConflictResolvingStrategy<T> strategy);
        IRouterDestinationBuilder<T> When(ICriteria<T> criteria);
        IRouterDestinationBuilder<T> When(Func<T, bool> criteria);
        IRouterConditionBuilder<T> WhenNoCriteriaMatchesRouteTo(string channel);
        RecipientListRouter<T> Build();
    }
}
