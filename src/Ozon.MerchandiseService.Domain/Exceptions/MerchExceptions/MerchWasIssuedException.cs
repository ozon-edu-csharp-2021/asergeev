using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class MerchWasIssuedException: Exception
    {
        public MerchWasIssuedException(string message) : base(message)
        {
            
        }
    }
}