using Microsoft.AspNetCore.Mvc;
using NewShoreFlights.Exceptions;
using NewShoreFlights.Flihts.Application.IServices;
using NewShoreFlights.Flihts.Domain.Models;

namespace NewShoreFlights.Flihts.Infraestructure
{
    [ApiController]
    [Route("[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly ILogger<FlightController> _logger;
        public FlightController(IFlightService flightService, ILogger<FlightController> logger)
        {
            _flightService = flightService;
            _logger=logger;
        }

        //<summary>
        //This endpoint will try to obtain all the flights
        //</summary>
        [HttpGet("flights")]
        public async Task<IActionResult> Flights()
        {
            _logger.LogInformation("Trying to obtain the flights");
            var flights = await _flightService.Flights();

            _logger.LogInformation("flights successfully obtained");

            return Ok(flights);
        }

        //<summary>
        //This endpoint will try to obtain the flights associated with an origin and destination
        //</summary>
        [HttpPost("journeys/{origin}/{destination}")]
        public async Task<IActionResult> Journeys([FromBody] List<GeneralFlight> generalFlights,
            string origin, string destination)
        {
            _logger.LogInformation("Trying to obtain the Journeys");

            if (origin.Equals(destination))
            {
                _logger.LogError("The origin can't be equal to the destination");
                throw new BadRequestException("The origin can't be equal to the destination");
            }

            if (!origin.Equals(origin.ToUpper()))
            {
                _logger.LogError("The origin must be capital letters");
                throw new BadRequestException("The origin must be capital letters");
            }

            if (!destination.Equals(destination.ToUpper()))
            {
                _logger.LogError("The destination must be capital letters");
                throw new BadRequestException("The destination must be capital letters");
            }

            if (origin.Length>3)
            {
                _logger.LogError("The origin must be maximum of 3 characters");
                throw new BadRequestException("The origin must be maximum of 3 characters");
            }

            if (destination.Length>3)
            {
                _logger.LogError("The destination must be maximum of 3 characters");
                throw new BadRequestException("The destination must be maximum of 3 characters");
            }

            var journeys = _flightService.Journeys(generalFlights, origin, destination);
            _logger.LogInformation("Journeys successfully obtained");

            return Ok(journeys);
        }

        //<summary>
        //This endpoint will try to obtain the flights associated with an origin and destination
        //</summary>
        [HttpGet("convertion")]
        public async Task<IActionResult> Convertion()
        {
            _logger.LogInformation("Trying to obtain the Convertion");
            var convertion = await _flightService.Convertion();
            _logger.LogInformation("Convertion successfully obtained");

            return Ok(convertion);
        }
    }
}
