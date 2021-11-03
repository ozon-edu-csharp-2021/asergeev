using Ozon.MerchandiseService.Domain.Models;

namespace Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public class Item: Entity
    {
        public ItemType ItemType {get;}

        public Item(ItemType itemType)
        {
            ItemType = itemType;
        }
    }
}