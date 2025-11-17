using System;
using System.Collections.Generic;
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

    [HttpGet("api/news/{id}/comments")]
    public ActionResult<CommentsDto> GetCommentsForNews(Guid newsId)
    {
        return new JsonResult(
            new Dictionary<string, object>
            {
                {"comments", commentsRepository.GetComments(newsId)}
            });
    }
}