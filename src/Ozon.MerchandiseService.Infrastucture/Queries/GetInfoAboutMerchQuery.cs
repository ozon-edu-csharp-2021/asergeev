using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace Ozon.MerchandiseService.Infrastucture.Queries
{
    public class GetInfoAboutMerchQuery: IRequest<MerchIssuanceInfo>
    {
        public long IdEmployee { get; init; }
    }
}