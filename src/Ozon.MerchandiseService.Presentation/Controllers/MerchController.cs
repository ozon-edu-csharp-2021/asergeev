using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchandiseService.Presentation.Models;
using Ozon.MerchandiseService.Presentation.Services;

namespace Ozon.MerchandiseService.Presentation.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController: ControllerBase
    {
        private readonly IMerchService _merchService;

        public MerchController(IMerchService merchService)
        {
            _merchService = merchService;
        }

        [HttpGet]
        public async Task<ActionResult<MerchInfo>> GetInfoAboutMerch(MerchTypeModel model, CancellationToken token)
        {
            var info = await _merchService.GetInfoAboutMerch(model, token);
            return Ok(info);
        }
        
        [HttpPost]
        public async Task<ActionResult<MerchItem>> RequestMerch(MerchTypeModel model, CancellationToken token)
        {       
            var merchItem = await _merchService.RequestMerch(model, token);
             return Ok(merchItem);
        }
    }
}