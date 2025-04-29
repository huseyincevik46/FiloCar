using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiloCar.Application.Features.Drivers.Exceptions
{
    public class DriverException : Exception
    {
        public DriverException() : base("A business rule was violated.")
        {
        }

        public DriverException(string message) : base(message)
        {
        }

     
    }
}
