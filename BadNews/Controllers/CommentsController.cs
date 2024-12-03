using System;
using System.Collections.Immutable;
using System.Linq;
using BadNews.Extensions;
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
            var comments = new CommentsDto 
            { 
                NewsId = newsId, 
                Comments = commentsRepository
                    .GetComments(newsId)
                    .Select(x => x.ToDto())
                    .ToImmutableArray() 
            };

            return comments;
        }
    }
}