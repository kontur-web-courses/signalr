using System;
using System.Linq;
using BadNews.Mapping;
using BadNews.Models.Comments;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.Mvc;

namespace BadNews.Controllers;

[ApiController]
public class CommentsController(CommentsRepository commentsRepository) : ControllerBase
{
    [HttpGet("api/news/{id:guid}/comments")]
    public ActionResult<GetCommentsForNewsResponse> GetCommentsForNews(Guid id)
    {
        var comments = commentsRepository.GetComments(id);
        return new GetCommentsForNewsResponse
        {
            NewsId = id,
            Comments = comments.Select(CommentDtoMapper.MapToDto).ToArray(),
        };
    }
}
