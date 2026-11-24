using System;
using System.Linq;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers;

[ApiController]
public class CommentsController : ControllerBase
{
    private readonly CommentsRepository commentsRepository;

    public CommentsController(CommentsRepository commentsRepository)
    {
        this.commentsRepository = commentsRepository;
    }

    // GET
    [HttpGet("api/news/{id}/comments")]
    public ActionResult<CommentsDto> GetCommentsForNews(Guid id)
    {
        var comments = commentsRepository.GetComments(id).Select(x => new CommentDto
        {
            User = x.User,
            Value = x.Value,
        });
        
        var commentsDto = new CommentsDto
        {
            NewsId = id,
            Comments = [.. comments]
        };
        return Ok(commentsDto);
    }
}