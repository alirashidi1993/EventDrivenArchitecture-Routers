using EDA.Messages.PackageReservation;
using EDA.Router.Splitters.Composed;
using MassTransit;

namespace EDA.Router.Handlers
{
    public class ReservePackageHandler : IConsumer<ReservePackage>
    {
        private static ComposedSplitter<ReservePackage> splitter;

        static ReservePackageHandler()
        {
            splitter = CreateComposedSplitter
                .WhichTakesInput<ReservePackage>()
                .SplitBy(a => a.FlightReservation)
                .SplitBy(a => a.HotelReservation)
                .Build();
        }
        public async Task Consume(ConsumeContext<ReservePackage> context)
        {

            var individualCommands = splitter.Split(context.Message);

            foreach (var command in individualCommands)
            {
                await context.Send(new Uri("queue:Consumer1"), command);
            }
        }
    }
}
