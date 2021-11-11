using System;

namespace Ozon.MerchandiseService.Domain.Exceptions
{
    public class NullMerchIssuanceInfo: Exception
    {
        public NullMerchIssuanceInfo(string message) : base(message)
        {
        }
    }
}