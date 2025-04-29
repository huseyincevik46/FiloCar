using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Domain.Common;

namespace FiloCar.Domain.Entity
{
    public class Driver : IEntityBase
    {
        public int DriverId { get; set; }
        public int? DepartmanId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string PhoneNumber { get; set; } 
        public string LicenseNumber { get; set; } 

        public bool IsActive { get; set; } = true;

        public Departman Departman { get; set; } 
        public ICollection<VehicleAssigment> Assignments { get; set; } = new List<VehicleAssigment>();
    }
}
