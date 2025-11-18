using BadNews.Models.Comments;
using BadNews.Repositories.Comments;

namespace BadNews.Mapping;

public static class CommentDtoMapper
{
    public static CommentDto MapToDto(this Comment comment) => new()
    {
        User = comment.User,
        Value = comment.Value,
    };
}
