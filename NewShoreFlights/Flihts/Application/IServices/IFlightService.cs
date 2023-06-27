using NewShoreFlights.Flihts.Domain.Models;

namespace NewShoreFlights.Flihts.Application.IServices
{
    public interface IFlightService
    {
        Task<IEnumerable<GeneralFlight>> Flights();
        IEnumerable<Journey> Journeys(List<GeneralFlight> generalFlights, string origin, string destination);
        Task<Convertion> Convertion();
    }
}
