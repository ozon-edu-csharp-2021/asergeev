using System.Collections.Generic;
using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchName: ValueObject
    {
        public string Value { get; }

        public MerchName(string name)
        {
            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}