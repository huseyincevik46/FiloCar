using System;

namespace FiloCar.Application.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() : base("A business rule was violated.")
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
