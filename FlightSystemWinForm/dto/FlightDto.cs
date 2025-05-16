using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystemWinForm.dto
{
    public class FlightDto
    {
        public int id { get; set; }
        public string flightNumber { get; set; }
        public string destination { get; set; }
        public DateTime departureTime { get; set; }
        public string status { get; set; }
        public string Display => $"{flightNumber} - {destination} ({status})";
    }
}
