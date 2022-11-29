// Copyright Epic Games, Inc. All Rights Reserved.

using MetadataServer.Models;
using MetadataServer.Connectors;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LatestController : ControllerBase
    {

        private readonly ILogger<LatestController> _logger;

        public LatestController(ILogger<LatestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public LatestData Get(string? Project = null)
        {
            return SqlConnector.GetLastIds(Project);
        }
    }
}
