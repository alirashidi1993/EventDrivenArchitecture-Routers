using EDA.Messages.PackageReservation;
using MassTransit;
using Newtonsoft.Json;

namespace EDA.Consumer1.Handlers
{
    public class HotelReservationHandler : IConsumer<BookHotel>
    {
        public Task Consume(ConsumeContext<BookHotel> context)
        {
            Console.WriteLine("Message Received - BookHotel : ");
            Console.WriteLine("---------------------");
            var json = JsonConvert.SerializeObject(context.Message, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
            Console.WriteLine("---------------------");
            return Task.CompletedTask;
        }
    }
}
