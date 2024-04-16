namespace EDA.Router.Model.RouterBuilder
{
    public static class UseContentBasedRouter
    {
        public static IRouterConditionBuilder<T> For<T>()
        {
            return new ContentBasedRouterBuilder<T>();
        }
    }
}
