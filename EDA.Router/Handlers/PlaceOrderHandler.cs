using EDA.Messages.PurchaseOrders;
using EDA.Router.Model;
using EDA.Router.Model.RouterBuilder;
using MassTransit;

namespace EDA.Router.Handlers
{
    public class PlaceOrderHandler : IConsumer<PlaceOrder>
    {
        private static readonly IContentBasedRouter<PlaceOrder> router;

        static PlaceOrderHandler()
        {
            router = UseContentBasedRouter.For<PlaceOrder>()
                .When(m => m.VendorId == 1).RouteTo("queue:Consumer1")
                .When(m => m.VendorId == 2).RouteTo("queue:Consumer2")
                .WhenNoCriteriaMatchesRouteTo("queue:Consumer3")
                .Build();
        }
        public Task Consume(ConsumeContext<PlaceOrder> context)
        {
            var destination = router.FindDestinationFor(context.Message);

            Console.WriteLine($"Message Received. Routing the message to : {destination}");

            return context.Send(new Uri(destination), context.Message);
        }
    }
}
