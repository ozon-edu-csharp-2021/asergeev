using MediatR;

namespace Ozon.MerchandiseService.Infrastucture.Commands
{
    public class CreateMerchItemCommand: IRequest
    {
        public long Id { get; }
        public string MerchName { get;}
        public int ItemType { get;}
        public string MerchRank { get; }
        public int ClothingSize { get; }
    }
}