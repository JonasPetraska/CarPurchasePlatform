using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarHistorySample.Models
{
    public class CarReport
    {
        public string VIN { get; set; }
        public int OwnersCount { get; set; }
        public string Country { get; set; }

        public bool HasBeenSoldBefore { get; set; }
        public bool HasBeenConfiscated { get; set; }
        public double LastListingPrice { get; set; }
        public bool IsWanted { get; set; }
        public bool HadWaterDamage { get; set; }
    }
}
