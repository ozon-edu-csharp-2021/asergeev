using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ozon.MerchandiseService.Domain.AggregationModels.MerchItemAggregate;
using Ozon.MerchandiseService.Domain.Exceptions;
using Ozon.MerchandiseService.Domain.Models;
using Ozon.MerchandiseService.Infrastucture.Commands;

namespace Ozon.MerchandiseService.Infrastucture.Handlers
{
    public class CreateMerchItemCommandHandler: IRequestHandler<CreateMerchItemCommand>
    {
        private readonly IMerchItemRepository _merchItemRepository;

        public CreateMerchItemCommandHandler(IMerchItemRepository employeeRepository)
        {
            _merchItemRepository = employeeRepository;
        }
        
        public async Task<Unit> Handle(CreateMerchItemCommand request, CancellationToken cancellationToken)
        {
            var merchItem = await _merchItemRepository.FindByIdAsync(new Id(request.Id), cancellationToken);
            if (merchItem is not null)
                throw new AlreadyExistsException($"Merch Item with id {request.Id} already exists");

            var newMerchItem = new MerchItem(
                new Id(request.Id),
                new MerchName(request.MerchName),
                new Item(ItemType.GetAll<ItemType>()
                        .FirstOrDefault(it => it.Id.Equals(request.ItemType))),
                    Enumeration
                        .GetAll<MerchRankType>()
                        .FirstOrDefault(it => it.Id.Equals(request.MerchRank)),
                Enumeration
                    .GetAll<ClothingSize>()
                    .FirstOrDefault(it => it.Id.Equals(request.ClothingSize))
            );

            await _merchItemRepository.CreateAsync(newMerchItem, cancellationToken);
            await _merchItemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}