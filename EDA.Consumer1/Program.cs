using EDA.Consumer1.Handlers;
using MassTransit;

Console.WriteLine("------ Consumer 1 ------");

var bus = Bus.Factory.CreateUsingRabbitMq(conf =>
{
    conf.Host("localhost");
    conf.ReceiveEndpoint("Consumer1", ep =>
    {
        ep.Consumer<PlaceOrderHandler>();
        ep.Consumer<FlightReservationHandler>();
        ep.Consumer<HotelReservationHandler>();
    });
});

await bus.StartAsync();

Console.WriteLine("Bus started. waiting for messages");
Console.WriteLine("---------------------------------");

Console.ReadLine();