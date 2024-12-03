using BadNews.Models.Comments;
using BadNews.Repositories.Comments;

namespace BadNews.Extensions
{
    public static class CommentExtensions
    {
        public static CommentDto ToDto(this Comment comment)
        {
            return new CommentDto
            {
                User = comment.User,
                Value = comment.Value,
            };
        }
    }
}
