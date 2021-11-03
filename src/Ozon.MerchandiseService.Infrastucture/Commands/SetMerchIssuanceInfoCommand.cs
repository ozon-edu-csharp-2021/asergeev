using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;

namespace Ozon.MerchandiseService.Infrastucture.Commands
{
    public class SetMerchIssuanceInfoCommand: IRequest
    {
        public string EmployeeEmail { get; }
    }
}