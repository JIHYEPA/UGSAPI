using MetadataServer.Connectors;
using MetadataServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TelemetryController : ControllerBase
    {
        public void Post([FromBody] TelemetryTimingData Data, string Version, string IpAddress)
        {
            SqlConnector.PostTelemetryData(Data, Version, IpAddress);
        }
    }
}
