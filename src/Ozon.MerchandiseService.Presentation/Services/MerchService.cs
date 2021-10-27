using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchandiseService.Presentation.Controllers;
using Ozon.MerchandiseService.Presentation.Models;

namespace Ozon.MerchandiseService.Presentation.Services
{
    public interface IMerchService
    {
       Task<MerchItem> RequestMerch(MerchTypeModel model, CancellationToken token);
       Task<MerchInfo> GetInfoAboutMerch(MerchTypeModel model, CancellationToken token);
    }

    public class MerchService : IMerchService
    {
        public Task<MerchItem> RequestMerch(MerchTypeModel model, CancellationToken _)
        {
            return Task.FromResult( new MerchItem(model.ItemType));
        }

        public Task<MerchInfo> GetInfoAboutMerch(MerchTypeModel model, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }

}