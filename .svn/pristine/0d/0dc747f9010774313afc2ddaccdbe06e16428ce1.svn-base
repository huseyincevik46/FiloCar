using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Domain.Common;

namespace FiloCar.Domain.Entity
{
    public class VehicleAssigment :IEntityBase
    {
        public int VehicleAssigmentId { get; set; }

        public int VehicleId { get; set; }
        public int DriverId { get; set; }

        public DateTime AssignmentStart { get; set; }
        public DateTime? AssignmentEnd { get; set; }
        public string? Notes { get; set; }

        public Vehicle Vehicle { get; set; } 
        public Driver Driver { get; set; } 
    }
}
