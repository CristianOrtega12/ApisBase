using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClaroFidelizacion.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    [ApiExplorerSettings(GroupName = "Users")]
    public class UsersController : ApiControllerBase
    {
    }
}
