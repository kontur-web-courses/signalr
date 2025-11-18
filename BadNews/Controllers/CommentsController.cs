using System;
using System.Collections.ObjectModel;
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

        [HttpGet("api/news/{id}/comments")]
        public ActionResult<CommentsDto> GetCommentsForNews(Guid newsId)
        {
            var comments = commentsRepository
                .GetComments(newsId)
                .Select(x => new CommentDto
                {
                    User = x.User,
                    Value = x.Value
                })
                .ToList();
            var commentsDto = new CommentsDto
            {
                NewsId = newsId,
                Comments = new ReadOnlyCollection<CommentDto>(comments)
            };
            return Ok(commentsDto);
        }
    }
}