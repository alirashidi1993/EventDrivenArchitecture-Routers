namespace EDA.Router.Model.RouterBuilder
{
    public interface IRouterDestinationBuilder<T>
    {
        IRouterConditionBuilder<T> RouteTo(params string[] channelNames);
    }
}
