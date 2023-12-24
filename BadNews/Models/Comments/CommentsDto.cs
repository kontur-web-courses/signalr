using System;
using System.Collections.Generic;
using BadNews.Repositories.Comments;

namespace BadNews.Models.Comments
{
    public class CommentsDto
    {
        public CommentsDto(Guid newsId, IReadOnlyCollection<CommentDto> comments)
        {
            NewsId = newsId;
            Comments = comments;
        }

        public Guid NewsId { get; set; }

        public IReadOnlyCollection<CommentDto> Comments { get; set; }
    }
}