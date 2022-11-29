using MetadataServer.Connectors;
using MetadataServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CISController : ControllerBase
    {
        public long[] Get(string? Project = null)
        {
            LatestData LatestIDs = SqlConnector.GetLastIds(Project);
            return new long[] { LatestIDs.LastEventId, LatestIDs.LastCommentId, LatestIDs.LastBuildId };
        }
        public List<BuildData> Get(string Project, long LastBuildId)
        {
            return SqlConnector.GetBuilds(Project, LastBuildId);
        }
        public void Post([FromBody] BuildData Build)
        {
            SqlConnector.PostBuild(Build);
        }
    }
}
