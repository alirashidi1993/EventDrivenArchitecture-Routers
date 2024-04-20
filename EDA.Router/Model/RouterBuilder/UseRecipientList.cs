namespace EDA.Router.Model.RouterBuilder
{
    public static class UseRecipientList
    {
        public static IRouterConditionBuilder<T> For<T>()
        {
            return new RecipientListBuilder<T>();
        }
    }
}
