using EDA.Consumer2.Handlers;
using MassTransit;

Console.WriteLine("------ Consumer 2 ------");

var bus = Bus.Factory.CreateUsingRabbitMq(conf =>
{
    conf.Host("localhost");
    conf.ReceiveEndpoint("Consumer2", ep =>
    {
        ep.Consumer<PlaceOrderHandler>();
    });
});

await bus.StartAsync();

Console.WriteLine("Bus started. waiting for messages");
Console.WriteLine("---------------------------------");

Console.ReadLine();