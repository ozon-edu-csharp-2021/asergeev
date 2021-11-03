using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace Ozon.MerchandiseService.Domain.Events
{
    //набор мерча для выдачи сформирован
    
    public class MerchSetFormedDomainEvent: INotification
    {
        public MerchSet MerchSet { get; }

        public MerchSetFormedDomainEvent(MerchSet set)
        {
            MerchSet = set;
        }
    }
}