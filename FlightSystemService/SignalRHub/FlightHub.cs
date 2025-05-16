using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FlightSystemService.SignalRHub
{
    public class FlightHub : Hub
    {
        public async Task SendFlightStatus(int flightId, string status)
        {
            await Clients.All.SendAsync("ReceiveFlightStatus", flightId, status);
        }
    }

}
