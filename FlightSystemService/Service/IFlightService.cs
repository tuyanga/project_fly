using FlightSystemDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystemService.Service
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetAllFlightsAsync();
        Task<Flight> GetFlightByIdAsync(int id);
        Task<bool> UpdateFlightStatusAsync(int flightId, FlightStatus newStatus);
    }
}
