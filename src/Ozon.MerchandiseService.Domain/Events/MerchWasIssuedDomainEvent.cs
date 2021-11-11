using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;

namespace Ozon.MerchandiseService.Domain.Events
{
    // Мерч был выдан сотруднику с определенным email
    public class MerchHaveBeenIssuedDomainEvent: INotification
    {
        public Email Email { get; }

        public MerchHaveBeenIssuedDomainEvent(Email employeeEmail)
        {
            Email = employeeEmail;
        }
    }
}