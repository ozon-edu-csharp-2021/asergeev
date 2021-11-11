using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class DoubleCreateMerchSetException: Exception
    {
        public DoubleCreateMerchSetException(string message) : base(message)
        {
            
        }
    }
}