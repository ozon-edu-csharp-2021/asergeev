using Ozon.MerchandiseService.Presentation.Models;

public class MerchItem
{
    public MerchItem(long id, string name, string clothingSize,string itemType)
    {
        Id = id;
        Name = name;
        ClothingSize = clothingSize;
        ItemType = itemType;
    }

    public long Id { get; }
    public string Name { get; }
    public string ClothingSize { get; }
    public string ItemType { get; }
}