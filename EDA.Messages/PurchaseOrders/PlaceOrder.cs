namespace EDA.Messages.PurchaseOrders
{
    public class PlaceOrder : Core.ICommand
    {
        public long OrderNumber { get; set; }
        public long VendorId { get; set; }
        public DateTime IssueDate { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        public Guid MessageId { get; } = Guid.NewGuid();

        public long TotalPriceOfItems()
        {
            return (long)(OrderLines?.Sum(ol => ol.PricePerUnit * ol.Quantity)??0);
        }
    }
}
