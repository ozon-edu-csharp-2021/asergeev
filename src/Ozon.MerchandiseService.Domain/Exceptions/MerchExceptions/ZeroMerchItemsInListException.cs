using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class ZeroMerchItemsInListException: Exception
    {
        public ZeroMerchItemsInListException(string message) : base(message)
        {
        }
    }
}