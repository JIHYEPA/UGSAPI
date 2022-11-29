using MetadataServer.Connectors;
using MetadataServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetadataServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        
        public List<CommentData> Get(string Project, long LastCommentId)
        {
            return SqlConnector.GetComments(Project, LastCommentId);
        }

        public void Post([FromBody] CommentData Comment)
        {
            SqlConnector.PostComment(Comment);
        }
    }
}
