using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetAllWithFilters
{
    public  class GetAllWithFiltersQuery : IRequest<List<GetAllWithFiltersResponse>>
    {
        public DateTime? MaintenanceDate { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
