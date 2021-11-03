using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class AlreadyExistsException: Exception
    {
        public AlreadyExistsException(string message) : base(message){}
    }
}