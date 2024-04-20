using EDA.Messages.PurchaseOrders;
using MassTransit;
using Newtonsoft.Json;
using System.Xml;

namespace EDA.Consumer1.Handlers
{
    public class PlaceOrderHandler : IConsumer<PlaceOrder>
    {
        public Task Consume(ConsumeContext<PlaceOrder> context)
        {
            Console.WriteLine("Message Received");
            Console.WriteLine(
                JsonConvert.SerializeObject(context.Message,
                Newtonsoft.Json.Formatting.Indented));
            Console.WriteLine("----------------------------");
            return Task.CompletedTask;
        }
    }
}
