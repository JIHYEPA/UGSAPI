using MetadataServer.Connectors;
using MetadataServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        public List<EventData> Get(string Project, long LastEventId)
        {
            return SqlConnector.GetUserVotes(Project, LastEventId);
        }

        public void Post([FromBody] EventData Event)
        {
            SqlConnector.PostEvent(Event);
        }
    }
}
