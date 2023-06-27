using NewShoreFlights.Flihts.Domain.IRepositories;
using NewShoreFlights.Flihts.Domain.Models;
using Newtonsoft.Json;

namespace NewShoreFlights.Flihts.Domain.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IConfiguration _configuration;
        public FlightRepository(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        public async Task<IEnumerable<GeneralFlight>> Flights()
        {
            var urlApi = _configuration["EnviromentVariables:UrlApiNewshore"];

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(urlApi);
                var flights = JsonConvert.DeserializeObject<List<GeneralFlight>>(response);

                return flights;
            }
        }

        public async Task<Convertion> Convertion()
        {
            var urlApi = _configuration["EnviromentVariables:UrlApiMoney"];

            using (var client = new HttpClient())
            {
                var response = await client.GetStringAsync(urlApi);
                var convertion = JsonConvert.DeserializeObject<Convertion>(response);

                return convertion;
            }
        }
    }
}
