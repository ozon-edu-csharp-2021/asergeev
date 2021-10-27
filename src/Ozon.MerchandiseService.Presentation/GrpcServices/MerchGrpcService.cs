using System.Threading.Tasks;
using Grpc.Core;
using Ozon.MerchandiseService.Grpc;
using Ozon.MerchandiseService.Presentation.Models;
using Ozon.MerchandiseService.Presentation.Services;

namespace Ozon.MerchandiseService.Presentation.GrpcServices
{
    public class MerchGrpcService: MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        private readonly IMerchService _merchService;

        public MerchGrpcService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        public override async Task<GetInfoAboutMerchResponse> GetInfoAboutMerch(GetInfoAboutMerchRequest request, ServerCallContext context)
        {
            return new GetInfoAboutMerchResponse();
        }

        public override async Task<GetMerchResponse> GetMerch(GetMerchRequest request, ServerCallContext context)
        {
            return new GetMerchResponse();
        }
    }
}