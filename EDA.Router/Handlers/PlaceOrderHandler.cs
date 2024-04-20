using EDA.Messages.PurchaseOrders;

using MassTransit;

namespace EDA.Router.Handlers
{
    public class PlaceOrderHandler : IConsumer<PlaceOrder>
    {


        public async Task Consume(ConsumeContext<PlaceOrder> context)
        {

        }
    }
}
