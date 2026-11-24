using System;
using System.Linq;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers;

[ApiController]
public class CommentsController(CommentsRepository commentsRepository) : ControllerBase
{
    [HttpGet("api/news/{id}/comments")]
    public ActionResult<CommentsDto> GetCommentsForNews([FromRoute(Name = "id")] Guid newsId)
    {
        var comments = commentsRepository.GetComments(newsId);
        var result = new CommentsDto
        {
            NewsId = newsId,
            Comments = comments.Select(comment => new CommentDto
            {
                User = comment.User,
                Value = comment.Value
            }).ToArray()
        };

        return Ok(result);
    }
}