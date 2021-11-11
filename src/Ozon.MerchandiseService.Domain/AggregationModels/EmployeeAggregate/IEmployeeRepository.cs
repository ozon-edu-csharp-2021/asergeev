using System.Threading;
using System.Threading.Tasks;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;

namespace Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        Task<Employee> FindEmployeeByEmailAsync(Email email, CancellationToken cancellationToken = default);
        Task<Employee> FindEmployeeById(Id id, CancellationToken cancellationToken = default);
    }
}