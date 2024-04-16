namespace EDA.Router.Model.RouterBuilder
{
    public interface IRouterDestinationBuilder<T>
    {
        IRouterConditionBuilder<T> RouteTo(string channelName);
    }
}
