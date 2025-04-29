using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FiloCar.Application.Features.Drivers.Command.RemoveDriverCommand
{
    public class RemoveDriverRequest : IRequest<Unit>
    {
   
        public int DriverId { get; set; }
        public int? DepartmanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
