﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Domain.Common;

namespace FiloCar.Domain.Entity
{
    public class MaintenanceRecord : IEntityBase //Bakım Kaydı
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }

        public string Description { get; set; } = null!;
        public DateTime MaintenanceDate { get; set; }
        public double Cost { get; set; }
        public int KmAtMaintenance { get; set; }
        public string? ServiceCompanyName { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
