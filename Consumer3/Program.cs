using EDA.Consumer3.Handlers;
using MassTransit;

Console.WriteLine("------ Consumer 3 ------");

var bus = Bus.Factory.CreateUsingRabbitMq(conf =>
{
    conf.Host("localhost");
    conf.ReceiveEndpoint("Consumer3", ep =>
    {
        ep.Consumer<PlaceOrderHandler>();
    });
});

await bus.StartAsync();

Console.WriteLine("Bus started. waiting for messages");
Console.WriteLine("---------------------------------");

Console.ReadLine();