using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ozon.MerchandiseService.Domain.Contracts;

namespace Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate
{
    public interface IMerchItemRepository: IRepository<MerchItem>
    {
       Task<MerchItem> CreateAsync(MerchItem itemToCreate, CancellationToken cancellationToken = default);
       Task<MerchItem> UpdateAsync(MerchItem itemToUpdate, CancellationToken cancellationToken = default);
       Task<MerchItem> FindByIdAsync(Id merchId, CancellationToken cancellationToken = default);
       Task<List<MerchItem>> FindByMerchRankAsync(MerchRankType rank, CancellationToken cancellationToken = default);
    }
}