using Application.Cqrs.User.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClaroFidelizacion.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    //Se comenta por el token
    //[Authorize]
    [ApiExplorerSettings(GroupName = "Users")]
    public class UsersController : ApiControllerBase
    {
        /// <summary>
        /// Obtain all user
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCampaign([FromQuery] GetUsersQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
