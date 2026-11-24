using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BadNews.Hubs
{
    public class CommentsHub : Hub
    {
        public Task SendComment(string user, string message)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(message))
                throw new HubException("Укажите имя и текст комментария.");

            return Clients.All.SendAsync("ReceiveComment", user.Trim(), message.Trim());
        }
    }
}
