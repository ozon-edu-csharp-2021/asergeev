using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItem: Entity
    {
        public MerchItem(Id id, MerchName merchName, Item item, MerchRankType merchRank, ClothingSize clothingSize)
        {
            Id = id;
            MerchName = merchName;
            Item = item;
            MerchRank = merchRank;
            ClothingSize = clothingSize;
        }

        public Id Id { get; }
        public MerchName MerchName { get;}
        public Item Item { get;}
        public MerchRankType MerchRank { get; }
        public ClothingSize ClothingSize { get; }
    }
}