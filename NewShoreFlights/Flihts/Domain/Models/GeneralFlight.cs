﻿namespace NewShoreFlights.Flihts.Domain.Models
{
    public class GeneralFlight
    {
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public string FlightCarrier { get; set; }
        public string FlightNumber { get; set; }
        public double Price { get; set; }
    }
}