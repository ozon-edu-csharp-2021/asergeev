using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class NullEmployeeException: Exception
    {
        public NullEmployeeException(string message) : base(message){}
    }
}