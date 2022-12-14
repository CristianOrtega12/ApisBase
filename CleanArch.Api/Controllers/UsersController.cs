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
        /// Método que crea usuario.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] PostUserCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

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
