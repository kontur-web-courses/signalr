using BadNews.Repositories.Comments;

namespace BadNews.Models.Comments
{
    public class CommentDto
    {
        public string User { get; set; }
        
        public string Value { get; set; }


        public static CommentDto FromDomain(Comment comment) => new()
        {
            User = comment.User,
            Value = comment.Value
        };
    }
}