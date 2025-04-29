using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiloCar.Domain.Common;

namespace FiloCar.Domain.Entity
{
    public class Station : IEntityBase // İstasyon
    {
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int FuelLogId { get; set; }
        public string StationAddress { get; set; }
        public string StationPhone { get; set; }

        public ICollection<FuelLog> FuelLogs { get; set; } = new List<FuelLog>();
    }
}
