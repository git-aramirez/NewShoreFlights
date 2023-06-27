using Microsoft.AspNetCore.Mvc;
using NewShoreFlights.Flihts.Application.IServices;
using NewShoreFlights.Flihts.Domain.IRepositories;
using NewShoreFlights.Flihts.Domain.Models;

namespace NewShoreFlights.Flihts.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ILogger<FlightService> _logger;
        public FlightService(IFlightRepository flightRepository, ILogger<FlightService> logger)
        {
            _flightRepository = flightRepository;
            _logger=logger;
        }

        public Task<IEnumerable<GeneralFlight>> Flights()
        {
            return _flightRepository.Flights();
        }

        public IEnumerable<Journey> Journeys(List<GeneralFlight> generalFlights,
            string origin, string destination)
        {
            List<Journey> journeys = new List<Journey>();

            FindJourneys(generalFlights, new List<GeneralFlight>(), journeys, origin, origin,
                destination);

            return journeys;
        }

        private void FindJourneys(List<GeneralFlight> generalFlights, List<GeneralFlight> flights,
            List<Journey> journeys, string realOrigin, string origin, string destination)
        {
            for (int i = 0; i < generalFlights.Count(); i++)
            {
                var generalFlight = generalFlights[i];
                var departureFlight = generalFlight.DepartureStation;
                var arrivalFlight = generalFlight.ArrivalStation;

                if (departureFlight.Equals(origin) && arrivalFlight.Equals(destination))
                {
                    flights.Add(generalFlight);
                    var journey = GenerateJourney(realOrigin, destination, flights);
                    journeys.Add(journey);
                    flights.RemoveAt(flights.Count()-1);
                    _logger.LogInformation("A journey found: {Origin: "+journey.Origin+", Destination: "+journey.Destination+"}");

                    continue;
                }

                var isTheSameOrigin = isSameOrigin(flights, arrivalFlight);

                if (departureFlight.Equals(origin) && !isTheSameOrigin && !Contains(flights, generalFlight))
                {
                    flights.Add(generalFlight);
                    FindJourneys(generalFlights, flights, journeys, realOrigin, arrivalFlight, destination);
                    flights.RemoveAt(flights.Count()-1);

                    continue;
                }
            }
        }

        private Journey GenerateJourney(string origin, string destination, List<GeneralFlight> flights)
        {
            Journey journey = new Journey();
            journey.Origin = origin;
            journey.Destination = destination;
            journey.Price = flights.Select(fligth => fligth.Price).Sum();

            var journeyflights = new List<Flight>();
            foreach (var flight in flights)
            {
                var journeyfligh = new Flight();
                journeyfligh.Price = flight.Price;
                journeyfligh.Origin = flight.DepartureStation;
                journeyfligh.Destination = flight.ArrivalStation;

                var transport = new Transport();
                transport.FlightCarrier = flight.FlightCarrier;
                transport.FlightNumber = flight.FlightNumber;

                journeyfligh.Transport = transport;
                journeyflights.Add(journeyfligh);
            }

            journey.Flights = journeyflights;
            _logger.LogInformation("Jorney successfully added");

            return journey;
        }

        private bool isSameOrigin(List<GeneralFlight> flights, string arrivalFlight)
        {
            var isSameOrigen = false;
            if (flights.Count()>0)
            {
                for (int j = 0; j<flights.Count() && !isSameOrigen; j++)
                {
                    var tempOrigin = flights[j].DepartureStation;

                    if (arrivalFlight.Equals(tempOrigin))
                    {
                        isSameOrigen = true;
                    }
                }
            }

            return isSameOrigen;
        }
        private bool Contains(List<GeneralFlight> flights, GeneralFlight generalFlight)
        {
            foreach (var flight in flights)
            {
                if (flight.DepartureStation.Equals(generalFlight.DepartureStation) &&
                    flight.ArrivalStation.Equals(generalFlight.ArrivalStation) &&
                    flight.FlightCarrier.Equals(generalFlight.FlightCarrier) &&
                    flight.FlightNumber.Equals(generalFlight.FlightNumber) &&
                    flight.Price == flight.Price)
                {
                    return true;
                }
            }

            return false;
        }

        public Task<Convertion> Convertion()
        {
            return _flightRepository.Convertion();
        }
    }
}
