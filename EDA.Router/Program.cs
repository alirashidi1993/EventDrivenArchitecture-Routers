using EDA.Router.Handlers;
using MassTransit;

var bus = Bus.Factory.CreateUsingRabbitMq(conf =>
{
    conf.Host("localhost");
    conf.ReceiveEndpoint("Router", ep =>
    {
        ep.UseMessageRetry(r => r.Immediate(5));
        ep.Consumer<PlaceOrderHandler>();
    });
});

await bus.StartAsync();
Console.WriteLine("Bus is running. Waiting for messages...");
Console.ReadLine();