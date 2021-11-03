using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class DifferentMerchRankException: Exception
    {
        public DifferentMerchRankException(string message) : base(message)
        {
        }
    }
}