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
            Console.WriteLine("Message Received - CompletedOrder : ");
            Console.WriteLine("---------------------");
            var json = JsonConvert.SerializeObject(context.Message, Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine("---------------------");
            return Task.CompletedTask;
        }
    }
}
