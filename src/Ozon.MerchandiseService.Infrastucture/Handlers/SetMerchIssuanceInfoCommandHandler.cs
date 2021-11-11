using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Ozon.MerchandiseService.Domain.Exceptions;
using Ozon.MerchandiseService.Infrastucture.Commands;

namespace Ozon.MerchandiseService.Infrastucture.Handlers
{
    public class SetMerchIssuanceInfoCommandHandler: IRequestHandler<SetMerchIssuanceInfoCommand>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public SetMerchIssuanceInfoCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Unit> Handle(SetMerchIssuanceInfoCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindEmployeeByEmailAsync(
                new Email(request.EmployeeEmail), 
                cancellationToken);

            if (employee is null)
                throw new NullEmployeeException($"Employee with email {request.EmployeeEmail} doesn't exists!");

            var merchInfo = new MerchIssuanceInfo(
                employee.MerchSet.MerchRankType,
                new IssueStatus(true),
                DateTime.Now
                );

            employee = new Employee(
                employee.Id,
                employee.Email,
                employee.ClothingSize,
                merchInfo);

            await _employeeRepository.UpdateAsync(employee, cancellationToken);
            await _employeeRepository.UnitOfWork.SaveChangesAsync();
            return Unit.Value;
        }
    }
}