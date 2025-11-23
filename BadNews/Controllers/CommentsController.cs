using System;
using System.Linq;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BadNews.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsRepository commentsRepository;
        private readonly ILogger<CommentsController> logger;

        public CommentsController(CommentsRepository commentsRepository, ILogger<CommentsController> logger)
        {
            this.commentsRepository = commentsRepository;
            this.logger = logger;
        }

        [HttpGet("api/news/{id}/comments")]
        public ActionResult<CommentsDto> GetCommentsForNews(Guid newsId)
        {
            var comments = commentsRepository.GetComments(newsId)
                .Select(x => new CommentDto() { User = x.User, Value = x.Value }).ToList();
            logger.Log(LogLevel.Debug, "{@comments}", comments);
            var dto = new CommentsDto { NewsId = newsId, Comments = comments };
            return Ok(dto);
        }
    }
}