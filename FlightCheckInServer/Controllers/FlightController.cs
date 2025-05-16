using FlightSystemDatabase.Model;
using FlightSystemService.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace FlightSystemServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        
        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flights = await _flightService.GetAllFlightsAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] FlightStatus newStatus)
        {
            var result = await _flightService.UpdateFlightStatusAsync(id, newStatus);
            if (!result) return BadRequest("failed.");
            return Ok("Status updated.");
        }
    }
}
