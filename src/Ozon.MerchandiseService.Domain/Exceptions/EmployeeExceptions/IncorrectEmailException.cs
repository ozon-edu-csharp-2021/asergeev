using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class IncorrectEmailException: Exception
    {
        public IncorrectEmailException(string message) : base(message)
        {
            
        }
    }
}