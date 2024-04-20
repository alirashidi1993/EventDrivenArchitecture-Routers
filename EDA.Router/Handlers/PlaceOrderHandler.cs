using EDA.Messages.PurchaseOrders;
using EDA.Router.Model;
using EDA.Router.Model.Extensions;
using EDA.Router.Model.RouterBuilder;
using MassTransit;

namespace EDA.Router.Handlers
{
    public class PlaceOrderHandler : IConsumer<PlaceOrder>
    {
        private static readonly IRecipientList<PlaceOrder> router;

        static PlaceOrderHandler()
        {
            router = UseRecipientList.For<PlaceOrder>()
            .When(a => a.TotalPriceOfItems().IsInRangeOf(1, 10000))
            .RouteTo(
                "queue:Consumer1",
                "queue:Consumer2"
                )
            .When(a => a.TotalPriceOfItems().IsInRangeOf(10001, 20000))
            .RouteTo(
                "queue:Consumer2",
                "queue:Consumer3"
                )
            .WhenNoCriteriaMatchesRouteTo("queue:Consumer3")
            .Build();
        }

        public async Task Consume(ConsumeContext<PlaceOrder> context)
        {
            var destinations = router.FindDestinationsFor(context.Message);

            Console.WriteLine($"Message Received.");

            foreach(var dest in destinations)
            {
                Console.WriteLine($"Redirecting message to {dest}");
               await context.Send(new Uri(dest), context.Message);
            }
        }
    }
}
