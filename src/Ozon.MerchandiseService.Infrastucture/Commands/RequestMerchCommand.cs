using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace Ozon.MerchandiseService.Infrastucture.Commands
{
    public class RequestMerchCommand: IRequest<MerchSet>
    {
        public string Email { get; init; }
        public int MerchRank { get; init; }
    }
}