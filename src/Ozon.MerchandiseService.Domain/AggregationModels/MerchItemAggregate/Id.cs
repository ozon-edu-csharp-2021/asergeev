using System.Collections.Generic;
using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class Id: ValueObject
    {
        public long Value { get; }

        public Id(long value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}