using System;
using System.Collections.Generic;

namespace BadNews.Models.Comments;

public class GetCommentsForNewsResponse
{
    public required Guid NewsId { get; init; }

    public required IReadOnlyCollection<CommentDto> Comments { get; init; }
}
