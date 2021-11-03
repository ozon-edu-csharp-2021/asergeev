using System;
using System.Collections.Generic;
using Ozon.MerchandiseService.Domain.Exceptions;
using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchSet: ValueObject
    {
        public List<MerchItem> Set { get; private set; }
        public MerchRankType MerchRankType { get; }

        public MerchSet(List<MerchItem> merchItems)
        {
            if (merchItems.Count == 0)
                throw new ZeroMerchItemsInListException("List of merch items does not be empty!");
            
            var merchRank = merchItems[0].MerchRank;
            if (merchItems.Exists(item => !Equals(item.MerchRank, merchRank)))
                throw new DifferentMerchRankException("All items must be of the same merch rank!");

            Set = merchItems;
            MerchRankType = merchRank;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Set;
        }
    }
}