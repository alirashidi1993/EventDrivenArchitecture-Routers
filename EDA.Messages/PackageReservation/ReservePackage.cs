using EDA.Messages.Core;

namespace EDA.Messages.PackageReservation
{
    public class ReservePackage : ICommand
    {
        public Guid MessageId { get; } = Guid.NewGuid();
        public BookHotel HotelReservation { get; set; }
        public ReserveFlight FlightReservation { get; set; }
    }
}
