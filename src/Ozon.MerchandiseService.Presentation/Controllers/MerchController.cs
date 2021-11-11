using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ozon.MerchandiseService.Infrastucture.Commands;
using Ozon.MerchandiseService.Infrastucture.Queries;
using Ozon.MerchandiseService.Presentation.Models;
using Ozon.MerchandiseService.Presentation.Services;

namespace Ozon.MerchandiseService.Presentation.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    public class MerchController: ControllerBase
    {
        private readonly IMerchService _merchService;
        private readonly IMediator _mediator;

        public MerchController(IMerchService merchService, IMediator mediator)
        {
            _merchService = merchService;
            _mediator = mediator;
        }

        [HttpGet("info/{employeeId:long}")]
        public async Task<ActionResult<MerchInfo>> GetInfoAboutMerch(long id, CancellationToken token)
        {
            var getInfoAboutMerchQuery = new GetInfoAboutMerchQuery()
            {
                IdEmployee = id
            };
            var info = await _mediator.Send(getInfoAboutMerchQuery, token);
            
            var merchInfo = new MerchInfo(info.IssueStatus.WasIssued,
                info.MerchRankType.Name, 
                info.IssuanceDate.Value);
            
            return Ok(merchInfo);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<MerchItem>>> RequestMerch(EmployeeModel employeeModel, CancellationToken token)
        {
            var requestMerchCommand = new RequestMerchCommand()
            {
                Email = employeeModel.Email,
                MerchRank = employeeModel.MerchRank
            };
            var merchSet = await _mediator.Send(requestMerchCommand, token);
            List<MerchItem> merchList = new List<MerchItem>();
            
            foreach (var merch in merchSet.Set)
            {
                merchList.Add(new MerchItem(
                    merch.Id.Value, merch.MerchName.Value, 
                    merch.ClothingSize.Name, merch.Item.ItemType.Name 
                    ));
            }
            return Ok(merchList);
        }
    }
}