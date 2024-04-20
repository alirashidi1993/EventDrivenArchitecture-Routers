using EDA.Messages.PackageReservation;
using MassTransit;
using Newtonsoft.Json;

namespace EDA.Consumer1.Handlers
{
    public class FlightReservationHandler : IConsumer<ReserveFlight>
    {
        public Task Consume(ConsumeContext<ReserveFlight> context)
        {
            Console.WriteLine("Message Received - ReserveFlight : ");
            Console.WriteLine("---------------------");
            var json = JsonConvert.SerializeObject(context.Message, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine("---------------------");
            return Task.CompletedTask;
        }
    }
}
