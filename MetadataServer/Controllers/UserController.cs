using MetadataServer.Connectors;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public object Get(string Name)
        {
            long UserId = SqlConnector.FindOrAddUserId(Name);
            return new { Id = UserId };
        }
    }
}
