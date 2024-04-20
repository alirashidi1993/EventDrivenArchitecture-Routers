namespace EDA.Router.Model
{
    public interface IRecipientList<T>
    {
        List<string> FindDestinationsFor(T message);
    }
}
