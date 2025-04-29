using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Domain.Common;

namespace FiloCar.Domain.Entity
{
    public class Departman : IEntityBase
    {
        public int DepartmanId { get; set; }
        public string Name { get; set; } 
        public string City { get; set; }
        public string District { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<Driver> Drivers { get; set; } = new List<Driver>();


    }
}
