using System;
using System.Collections.Generic;
using BadNews.Repositories.Comments;

namespace BadNews.Models.Comments
{
    public class CommentDto
    {
        public string User { get; set; }
        
        public string Value { get; set; }
    }
}