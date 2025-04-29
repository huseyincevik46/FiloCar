using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Domain.Common;

namespace FiloCar.Domain.Entity
{
    public  class Vehicle : IEntityBase
    {
        public int VehicleId { get; set; }
        public int? DepartmanId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Km { get; set; }
        public bool IsActive { get; set; } = true;
        public string FuelType { get; set; } = null!;



        public DateTime AddTime { get; set; }= DateTime.Now;

        public Departman? Departman { get; set; } = null!;

        public ICollection<FuelLog> FuelLogs { get; set; } = new List<FuelLog>();
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
        public ICollection<VehicleAssigment> Assignments { get; set; } = new List<VehicleAssigment>();

    }
}
