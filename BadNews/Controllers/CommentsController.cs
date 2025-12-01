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
        
        [HttpGet("api/news/{id}/comments")]
        public ActionResult<CommentsDto> GetCommentsForNews(Guid newsId)
        {
            var comments = commentsRepository.GetComments(newsId)
                .Select(comment => new CommentDto
                    {
                        User = comment.User,
                        Value = comment.Value,
                    }
                )
                .ToList();
            
            return new ActionResult<CommentsDto>(new CommentsDto
            {
                Comments = comments,
                NewsId = newsId
            });
        }
    }
}