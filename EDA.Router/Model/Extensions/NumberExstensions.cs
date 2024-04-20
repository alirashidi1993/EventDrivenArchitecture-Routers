namespace EDA.Router.Model.Extensions
{
    public static class NumberExstensions
    {
        public static bool IsInRangeOf(this long value, decimal start, decimal end)
        {
            return value >= start && value <= end;
        }
    }
}
