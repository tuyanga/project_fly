using FlightSystemDatabase.Model;
using FlightSystemDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using FlightSystemService.SignalRHub;
namespace FlightSystemService.Service
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepo;
        private readonly IHubContext<FlightHub> _hubContext;

        public FlightService(IFlightRepository flightRepo, IHubContext<FlightHub> hubContext)
        {
            _flightRepo = flightRepo;
            _hubContext = hubContext;
        }

        public async Task<IEnumerable<Flight>> GetAllFlightsAsync()
        {
            return await _flightRepo.GetAllAsync();
        }

        public async Task<Flight> GetFlightByIdAsync(int id)
        {
            return await _flightRepo.GetByIdAsync(id);
        }
        public async Task<bool> UpdateFlightStatusAsync(int flightId, FlightStatus newStatus)
        {
            var flight = await _flightRepo.GetByIdAsync(flightId);
            if (flight == null)
                return false;

            flight.Status = newStatus;
            _flightRepo.Update(flight);
            await _flightRepo.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveFlightStatus", flightId, newStatus.ToString());
            return true;
        }
    }
}
