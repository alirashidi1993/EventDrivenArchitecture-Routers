using EDA.Client.CommandLineInterface;
using EDA.Client.Factories;
using EDA.Messages.Core;
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
            .WithChoices(
                "1. Send 'PlaceOrder' Command (Iterating Splitter)",
                "2. Send 'ReservePackage' Command (Composite Message Splitter)",
                "99.Exit")
            ).GetIndexOfSelectedChoice();

            if (choice == 1)
            {
                await SendCommand(PurchaseOrderFactory.CreateCommand);
            }
            if (choice == 2)
            {
                await SendCommand(PackageReservationFactory.CreateCommand);
            }
            if (choice == 99)
            {
                Environment.Exit(1941);
            }
        }
    }
    private static async Task SendCommand<T>(Func<T> factory) where T : class, ICommand
    {
        long choice = 2;

        T command = null;
        while (choice == 2)
        {
            command = factory();
            Console.WriteLine(JsonConvert.SerializeObject(command, Formatting.Indented));

            choice = CommandLine.AskAQuestion(q =>
            q.About("Select the next action:")
            .WithChoices(
                "1.Send",
                "2.Regenerate"
                )
            ).GetIndexOfSelectedChoice();

            if (choice == 1) break;

            Console.Clear();
        }

        var endpoint = await _bus.GetSendEndpoint(new Uri("queue:Router"));
        await endpoint.Send<T>(command);

        Console.WriteLine("Sent to Router!");
        Console.WriteLine("------------------------ Press Any Key to Continue ---------------");
        Console.ReadLine();
    }
}