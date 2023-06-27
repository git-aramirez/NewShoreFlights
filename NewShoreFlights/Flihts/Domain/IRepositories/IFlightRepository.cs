using NewShoreFlights.Flihts.Domain.Models;

namespace NewShoreFlights.Flihts.Domain.IRepositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<GeneralFlight>> Flights();
        Task<Convertion> Convertion();
    }
}
