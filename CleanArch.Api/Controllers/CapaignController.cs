using Application.Cqrs.Campaign.Queries;
using ClaroFidelizacion.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Corporation.Indicators.Api.Controllers
{
    [Route("api/Campaign")]
    [ApiController]
    //[Authorize]
    [ApiExplorerSettings(GroupName = "Campaign")]
    public class CapaignController : ApiControllerBase
    {
        /// <summary>
        /// Obtain all campaign
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCampaign([FromQuery] GetCampaignsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        /// <summary>
        /// Obtain all campaign by user
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet("GetCampaignByUser")]
        public async Task<IActionResult> GetCampaignByUser([FromQuery] GetCampaignsByUserQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
