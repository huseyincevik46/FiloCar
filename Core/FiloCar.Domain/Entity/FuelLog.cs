using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Domain.Common;

namespace FiloCar.Domain.Entity
{
    public class FuelLog : IEntityBase
    {

        public int FuelLogId { get; set; }
        public int VehicleId { get; set; }
        public int StationId { get; set; }

        public DateTime FuelDate { get; set; }
        public double Liter { get; set; }
        public double LiterCount { get; set; }
        public int CurrentKm { get; set; }

        public Vehicle Vehicle { get; set; }
        public Station Station { get; set; } 
    }
}
