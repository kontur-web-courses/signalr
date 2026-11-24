using System.Threading.Tasks;
using BadNews.Repositories.Comments;
using Microsoft.AspNetCore.SignalR;

namespace BadNews.Hubs
{
    public class CommentsHub: Hub
    {
        private readonly CommentsRepository commentsRepository;

        public CommentsHub(CommentsRepository commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public async Task SendComment(string user, string message)
        {
            commentsRepository.AddComment(user, message);
            await Clients.All.SendAsync("ReceiveComment", user, message).ConfigureAwait(false);
        }
    }
}