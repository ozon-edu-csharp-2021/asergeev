using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class NullMerchSetException: Exception
    {
        public NullMerchSetException(string message) : base(message)
        {
            
        }
    }
}