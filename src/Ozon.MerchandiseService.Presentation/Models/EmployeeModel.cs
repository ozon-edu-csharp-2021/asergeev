using Ozon.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;

namespace Ozon.MerchandiseService.Presentation.Models
{
    public class EmployeeModel
    {
        public long Id { get; }
        public string Email { get; }
        public int MerchRank { get; }

        public EmployeeModel(long id, string email, int merchRank)
        {
            Id = id;
            Email = email;
            MerchRank = merchRank;
        }
    }
}