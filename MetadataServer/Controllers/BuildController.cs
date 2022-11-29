using MetadataServer.Connectors;
using MetadataServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildController : ControllerBase
    {
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
