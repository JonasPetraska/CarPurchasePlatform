using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarVerticalSample.Models
{
    public class CarHistoryReport
    {
        public string VIN { get; set; }
        public int OwnersCount { get; set; }
        public string Country { get; set; }

        public bool IsStolen { get; set; }
        public bool WasTaxi { get; set; }
        public bool HadAccidents { get; set; }
        public int AccidentsCount { get; set; }
    }
}
