using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetAllWithFilters
{
    public  class GetAllWithFiltersResponse

    {
        public int Id { get; set; }
        public int VehicleId { get; set; }

        public string Description { get; set; } = null!;
        public DateTime MaintenanceDate { get; set; }
        public double Cost { get; set; }
        public int KmAtMaintenance { get; set; }
        public string? ServiceCompanyName { get; set; }

    }
}
