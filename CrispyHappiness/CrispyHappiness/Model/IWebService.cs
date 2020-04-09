using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CrispyHappiness.Model
{
    public interface IWebService
    {
        Task<Model.User> Login(string username, string password);
        Task<Model.User> Register(Model.User user);
        Task<Model.User[]> GetFriends(int userId);
        Task<Model.User> AddFriend(int userId, string username);
        Task<Model.Conversation[]> GetConversations(int userId);
        //Task<Model.Message[]> GetMessages(int conversationId);
        Task<ObservableCollection<Model.Message>> GetMessages(int conversationId);
        Task<Model.Message> SendMessage(Model.Message message);
    }
}
