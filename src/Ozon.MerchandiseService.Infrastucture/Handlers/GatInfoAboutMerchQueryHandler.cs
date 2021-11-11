using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Ozon.MerchandiseService.Domain.Exceptions;
using Ozon.MerchandiseService.Infrastucture.Queries;

namespace Ozon.MerchandiseService.Infrastucture.Handlers
{
    public class GatInfoAboutMerchQueryHandler: IRequestHandler<GetInfoAboutMerchQuery, MerchIssuanceInfo>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GatInfoAboutMerchQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<MerchIssuanceInfo> Handle(GetInfoAboutMerchQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindEmployeeById(
                new Id(request.IdEmployee), cancellationToken);

            if (employee is null)
                throw new NullEmployeeException($"Employee with id {request.IdEmployee} doesn't exists!");

            return employee.MerchIssuanceInfo;
        }
    }
}