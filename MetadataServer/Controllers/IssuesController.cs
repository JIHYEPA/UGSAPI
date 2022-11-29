using MetadataServer.Connectors;
using MetadataServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssuesController : ControllerBase
    {
        [HttpGet]
        public List<IssueData> Get(bool IncludeResolved = false, int MaxResults = -1)
        {
            return SqlConnector.GetIssues(IncludeResolved, MaxResults);
        }

        [HttpGet]
        public List<IssueData> Get(string User)
        {
            return SqlConnector.GetIssues(User);
        }

        [HttpGet]
        public IssueData Get(long id)
        {
            return SqlConnector.GetIssue(id);
        }

        [HttpPut]
        public void Put(long id, IssueUpdateData Issue)
        {
            SqlConnector.UpdateIssue(id, Issue);
        }

        [HttpPost]
        public object Post(IssueData Issue)
        {
            long IssueId = SqlConnector.AddIssue(Issue);
            return new { Id = IssueId };
        }

        [HttpDelete]
        public void Delete(long id)
        {
            SqlConnector.DeleteIssue(id);
        }
    }


    [ApiController]
    [Route("api/issues/{IssueId}/builds")]
    public class IssueBuildsSubController : ControllerBase
    {
        [HttpGet]
        public List<IssueBuildData> Get(long IssueId)
        {
            return SqlConnector.GetBuilds(IssueId);
        }

        [HttpPost]
        public object Post(long IssueId, [FromBody] IssueBuildData Data)
        {
            long BuildId = SqlConnector.AddBuild(IssueId, Data);
            return new { Id = BuildId };
        }
    }


    [ApiController]
    [Route("api/issues/{IssueId}/diagnostics")]
    public class IssueDiagnosticsSubController : ControllerBase
    {
        [HttpGet]
        public List<IssueDiagnosticData> Get(long IssueId)
        {
            return SqlConnector.GetDiagnostics(IssueId);
        }

        [HttpPost]
        public void Post(long IssueId, [FromBody] IssueDiagnosticData Data)
        {
            SqlConnector.AddDiagnostic(IssueId, Data);
        }
    }

    [ApiController]
    [Route("api/issuebuilds/{BuildId}")]
    public class IssueBuildsController : ControllerBase
    {
        [HttpGet]
        public IssueBuildData Get(long BuildId)
        {
            return SqlConnector.GetBuild(BuildId);
        }

        [HttpPut]
        public void Put(long BuildId, [FromBody] IssueBuildUpdateData Data)
        {
            SqlConnector.UpdateBuild(BuildId, Data.Outcome);
        }
    }


    [ApiController]
    [Route("api/issues/{IssueId}/watchers")]
    public class IssueWatchersController : ControllerBase
    {
        [HttpGet]
        public List<string> Get(long IssueId)
        {
            return SqlConnector.GetWatchers(IssueId);
        }

        [HttpPost]
        public void Post(long IssueId, [FromBody] IssueWatcherData Data)
        {
            SqlConnector.AddWatcher(IssueId, Data.UserName);
        }

        [HttpDelete]
        public void Delete(long IssueId, [FromBody] IssueWatcherData Data)
        {
            SqlConnector.RemoveWatcher(IssueId, Data.UserName);
        }
    }
}
