using EDA.Messages.Core;

namespace EDA.Messages.PackageReservation
{
    public class ReserveFlight : ICommand
    {
        public string FlightNumber { get; set; }
        public Dictionary<PassengerType, int> Count { get; set; }
        public Guid MessageId { get; } = Guid.NewGuid();
    }
    public enum PassengerType
    {
        Infant,
        Child,
        Adult
    }
}
