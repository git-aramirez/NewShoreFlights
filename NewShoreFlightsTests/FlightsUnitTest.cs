using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewShoreFlights.Flihts.Application.IServices;
using NewShoreFlights.Flihts.Domain.Models;

namespace NewShoreFlightsTests
{
    [TestClass]
    public class FlightsUnitTest
    {
        private static WebApplicationFactory<Program>? _factory = null;
        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Inicialize(TestContext contex)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void TestFindJourneysMZL_MED()
        {
            //Arrange
            using var scope = _scopeFactory?.CreateScope();
            var flightService = scope?.ServiceProvider?.GetService<IFlightService>();
            List<Journey> journeys = new List<Journey>();
            var generalFlights = new List<GeneralFlight>();
            AddGeneralFlights(generalFlights);
            //Act
            var result = flightService.Journeys(generalFlights, "MZL", "MDE");
            //Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestFindJourneysMZL_MDE()
        {
            //Arrange
            using var scope = _scopeFactory?.CreateScope();
            var flightService = scope?.ServiceProvider?.GetService<IFlightService>();
            List<Journey> journeys = new List<Journey>();
            var generalFlights = new List<GeneralFlight>();
            AddGeneralFlights(generalFlights);
            //Act
            var result = flightService.Journeys(generalFlights, "MZL", "MDE");
            //Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestFindJourneysMDE_MZL()
        {
            //Arrange
            using var scope = _scopeFactory?.CreateScope();
            var flightService = scope?.ServiceProvider?.GetService<IFlightService>();
            List<Journey> journeys = new List<Journey>();
            var generalFlights = new List<GeneralFlight>();
            AddGeneralFlights(generalFlights);
            //Act
            var result = flightService.Journeys(generalFlights, "MDE", "MZL");
            //Assert
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestFindJourneysBOG_PEI()
        {
            //Arrange
            using var scope = _scopeFactory?.CreateScope();
            var flightService = scope?.ServiceProvider?.GetService<IFlightService>();
            List<Journey> journeys = new List<Journey>();
            var generalFlights = new List<GeneralFlight>();
            AddGeneralFlights(generalFlights);
            //Act
            var result = flightService.Journeys(generalFlights, "BOG", "PEI");
            //Assert
            Assert.AreEqual(2, result.Count());
        }

        private void AddGeneralFlights(List<GeneralFlight> generalFlights)
        {
            List<string> ArrivalStations = new List<string>   { "PEI", "CTG", "BOG", "BCN", "CAN", "MZL", "PEI", "CAN", "CTG", "MDE", "MZL" };
            List<string> DepartureStations = new List<string> { "MZL", "MZL", "PEI", "MDE", "CTG", "BOG", "BOG", "MZL", "MDE", "CTG", "BCN" };
            List<string> FlightCarriers = new List<string>    { "CO", "CO", "CO", "CO", "CO", "CO", "CO", "CO", "CO", "CO", "CO" };
            List<string> FlightNumbers = new List<string>     { "8001", "8002", "8003", "8004", "8005", "8006", "8007", "8008", "8009", "8010", "8011" };
            List<double> Prices = new List<double>            { 200, 300, 250, 124, 110, 180, 240, 350, 300, 301, 342 };

            for (int i = 0; i < ArrivalStations.Count; i++)
            {
                GeneralFlight generalFlight = new GeneralFlight();
                generalFlight.ArrivalStation = ArrivalStations[i];
                generalFlight.DepartureStation = DepartureStations[i];
                generalFlight.FlightCarrier = FlightCarriers[i];
                generalFlight.FlightNumber = FlightNumbers[i];
                generalFlight.Price = Prices[i];
                generalFlights.Add(generalFlight);
            }
        }
    }
}