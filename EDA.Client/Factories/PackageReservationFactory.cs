using EDA.Messages.PackageReservation;
using FizzWare.NBuilder;

namespace EDA.Client.Factories
{
    public class PackageReservationFactory
    {
        public static ReservePackage CreateCommand()
        {
            return Builder<ReservePackage>.CreateNew()
                .With(e => e.FlightReservation = Builder<ReserveFlight>.CreateNew().Build())
                .With(e => e.HotelReservation = Builder<BookHotel>.CreateNew().Build())
                .Build();
        }
    }
}
