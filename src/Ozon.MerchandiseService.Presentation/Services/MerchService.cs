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
       Task<MerchItem> RequestMerch(EmployeeModel model, CancellationToken token);
       Task<MerchInfo> GetInfoAboutMerch(long idEmployee, CancellationToken token);
    }

    public class MerchService : IMerchService
    {
        public Task<MerchItem> RequestMerch(EmployeeModel model, CancellationToken _)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchInfo> GetInfoAboutMerch(long idEmployee, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }

}