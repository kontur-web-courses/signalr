using System;
using System.Collections.Generic;
using System.Linq;

namespace BadNews.Repositories.Comments
{
    public class CommentsRepository
    {
        private static readonly List<Comment> Storage = new();
        private static readonly object Lock = new();

        public IReadOnlyCollection<Comment> GetComments(Guid newsId)
        {
            lock (Lock)
            {
                if (Storage.Count == 0)
                {
                    return
                    [
                        new Comment("Вася", "Здесь был Вася!"),
                        new Comment("Воробушек", "ЧИК-ЧИРИК"),
                    ];
                }
                return Storage.ToList();
            }
        }

        public void AddComment(string user, string value)
        {
            lock (Lock)
            {
                Storage.Add(new Comment(user, value));
            }
        }
    }
}
