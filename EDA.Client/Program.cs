using EDA.Client.CommandLineInterface;
using EDA.Client.Factories;
using EDA.Messages.PurchaseOrders;
using MassTransit;
using Newtonsoft.Json;

internal class Program
{
    private static IBusControl _bus;

    static async Task Main(string[] args)
    {
        _bus = Bus.Factory.CreateUsingRabbitMq(conf =>
        {
            conf.Host("localhost");
        });
        await _bus.StartAsync();

        while (true)
        {
            Console.Clear();
            var choice = CommandLine.AskAQuestion(q =>
            q.About("Select the next action:")
            .WithChoices("1. Send 'PlaceOrder' Command", "99.Exit")
            ).GetIndexOfSelectedChoice();

            if (choice == 1)
            {
                await SendOrderMessage();
            }
            else if(choice==99)
            {
                Environment.Exit(1941);
            }
        }
    }
    private static async Task SendOrderMessage()
    {
        long choice = 2;
        PlaceOrder command = null;
        while (choice == 2)
        {
            command = PurchaseOrderFactory.CreateCommand();
            Console.WriteLine(JsonConvert.SerializeObject(command, Formatting.Indented));

            choice = CommandLine.AskAQuestion(q =>
            q.About("Select the next action:")
            .WithChoices("1.Send", "2.Regenerate")
            ).GetIndexOfSelectedChoice();

            if (choice == 1) break;

            Console.Clear();
        }

        var endpoint = await _bus.GetSendEndpoint(new Uri("queue:Router"));
        await endpoint.Send<PlaceOrder>(command);

        Console.WriteLine("Sent to Router!");
        Console.WriteLine("------------------------ Press Any Key to Continue ---------------");
        Console.ReadLine();
    }
}