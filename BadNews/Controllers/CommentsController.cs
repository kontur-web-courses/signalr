using System;
using System.Linq;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentsRepository commentsRepository;

        public CommentsController(CommentsRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        // GET
        [HttpGet("api/news/{newsId:guid}/comments")]
        public ActionResult<CommentsDto> GetCommentsForNews(Guid newsId)
        {
            var comments = commentsRepository.GetComments(newsId);
            var result = new CommentsDto
            {
                NewsId = newsId,
                Comments = comments.Select(c => new CommentDto {User = c.User, Value = c.Value}).ToList()
            };
            return Ok(result);
        }
    }
}