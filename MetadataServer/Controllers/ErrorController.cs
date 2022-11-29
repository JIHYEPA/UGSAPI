using MetadataServer.Connectors;
using MetadataServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        public List<TelemetryErrorData> Get(int Records = 10)
        {
            return SqlConnector.GetErrorData(Records);
        }

        public void Post([FromBody] TelemetryErrorData Data, string Version, string IpAddress)
        {
            SqlConnector.PostErrorData(Data, Version, IpAddress);
        }
    }
}
