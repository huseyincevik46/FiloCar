using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FiloCar.Application.Features.MaintenanceRecords.Queries.GetByServiceCompany
{
    public class GetByServiceComapanyQuery : IRequest<List<GetByServiceCompanyResponse>>
    {
        public string ServiceCompanyName { get; set; }

        public GetByServiceComapanyQuery(string serviceCompanyName)
        {
            ServiceCompanyName = serviceCompanyName;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(ServiceCompanyName))
            {
                throw new ArgumentException("Service company name cannot be null or empty.");
            }

        }
    }
}
