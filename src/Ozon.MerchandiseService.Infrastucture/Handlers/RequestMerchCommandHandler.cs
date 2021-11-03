using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Ozon.MerchandiseService.Domain.Exceptions;
using Ozon.MerchandiseService.Domain.Models;
using Ozon.MerchandiseService.Infrastucture.Commands;

namespace Ozon.MerchandiseService.Infrastucture.Handlers
{
    public class RequestMerchCommandHandler: IRequestHandler<RequestMerchCommand, MerchSet>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMerchItemRepository _merchItemRepository;

        public RequestMerchCommandHandler(IEmployeeRepository employeeRepository, IMerchItemRepository merchItemRepository)
        {
            _employeeRepository = employeeRepository;
            _merchItemRepository = merchItemRepository;
        }

        public async Task<MerchSet> Handle(RequestMerchCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindEmployeeByEmailAsync(
                new Email(request.Email), cancellationToken);

            if (employee is null)
                throw new NullEmployeeException($"Employee with email {request.Email} doesn't exists!");
            
            //если мерч уже был выдан раньше
            if (employee.MerchSet is not null)
                return employee.MerchSet;
            
            //получить список вещей согласно рангу
            var merchList = await _merchItemRepository.FindByMerchRankAsync(
                Enumeration
                    .GetAll<MerchRankType>()
                    .FirstOrDefault(it => it.Id.Equals(request.MerchRank)));
            
            // сформировать набор мерча
            var merchSet = new MerchSet(merchList);
            employee.AddMerchSet(merchSet);

            // Запрос к StockAPI для получения набора мерча
            
            // Отметить, что сотрудник получил мерч, если набор пришел от stockAPI
            var merchInfo = new MerchIssuanceInfo(
                Enumeration
                    .GetAll<MerchRankType>()
                    .FirstOrDefault(it => it.Id.Equals(request.MerchRank)),
                new IssueStatus(true),
                DateTime.Now
                );
            
            employee = new Employee(
                employee.Id,
                new Email(request.Email),
                employee.ClothingSize,
                employee.MerchSet,
                merchInfo
            );

            await _employeeRepository.UpdateAsync(employee, cancellationToken);
           // await _employeeRepository.UnitOfWork.SaveEntitiesAsync();
            
            return employee.MerchSet;
        }
    }
}