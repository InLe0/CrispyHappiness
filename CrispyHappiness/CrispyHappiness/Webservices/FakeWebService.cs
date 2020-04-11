using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CrispyHappiness.Model;

namespace CrispyHappiness.Webservices
{
    public class FakeWebService : IWebService
    {
        public int SleepDuration { get; set; }

        public int MyUserID { get; set; } = 1;


        public FakeWebService()
        {
            SleepDuration = 1;
        }
        private Task Sleep()
        {
            return Task.Delay(SleepDuration);
        }
        public async Task<User> Login(string username, string password)
        {
            await Sleep();
            if (username == "2")
            {
                return new User { Id = 2, Username = username };
            }
            else if (username == "3")
            {
                return new User { Id = 3, Username = username };
            }
            else 
            {
                return new User { Id = MyUserID, Username = username };
            }
        }

        public async Task<User> Register(User user)
        {
            await Sleep();
            return user;
        }
        public async Task<User[]> GetFriends(int userId)
        {
            await Sleep();

            return new[]
            {
                new User { Id = 2, Username = "Obama" },
                new User { Id = 3, Username = "Bush" },
                new User { Id = 4, Username = "Clinton" },
            };
        }
        public async Task<User> AddFriend(
        int userId, string username)
        {
            await Sleep();
            return new User { Id = 5, Username = username };
        }

        public async Task<Conversation[]> GetConversations(int userId)
        {
            await Sleep();
            switch (userId)
            {
                case 1:
                    return new[]
            {
                new Conversation { Id = 1, UserId = 2, Username = "Obama", Avatar = "settingscogwheelpngicon651309.png", LastMessage = "Hi", },
                new Conversation { Id = 2, UserId = 3, Username = "Bush", Avatar = "bb5962c0fda3373cbf16940486fab0dd.png", LastMessage = "Pretty well, still coding C#", },
                new Conversation { Id = 3, UserId = 4, Username = "Clinton", Avatar = "selfkeylogo.png", LastMessage = "It's great!",  },
            };
                case 2:
                    return new[]
            {
                new Conversation { Id = 1, UserId = 2, Username = "amabO", Avatar = "settingscogwheelpngicon651309.png", LastMessage = "iH", },
                new Conversation { Id = 2, UserId = 3, Username = "hsuB", Avatar = "bb5962c0fda3373cbf16940486fab0dd.png", LastMessage = "#C gnidoc llits ,llew ytterP", },
                new Conversation { Id = 3, UserId = 4, Username = "notnilC", Avatar = "selfkeylogo.png", LastMessage = "!taerg s'tI",  },
            };
                default:
                    return new[]
            {
                new Conversation { Id = 1, UserId = 2, Username = "Anonymous", Avatar = "settingscogwheelpngicon651309.png", LastMessage = "Got the Money?", },
                new Conversation { Id = 2, UserId = 3, Username = "EUGENE", Avatar = "bb5962c0fda3373cbf16940486fab0dd.png", LastMessage = "EEEEEEEUUUUUUUGGGEEEEEEEEEENNN!!!!", },
                new Conversation { Id = 3, UserId = 4, Username = "Keeper of Keys", Avatar = "selfkeylogo.png", LastMessage = "I also keep the grounds you know...",  },
            };
            }
        }

        //public async Task<Message[]> GetMessages(int conversationId)
        public async Task<ObservableCollection<Model.Message>> GetMessages(int conversationId)        
        {
            await Sleep();
            List<Model.Message> messageList = new List<Message>();
            switch (conversationId)
            {
                case 3:
                    messageList.AddRange(
                    new[]
                    {
                new Message
                {
                    Id = 1,
                    ConversationId = conversationId,
                    UserId = 2,
                    Text = "Eugene?",
                    Date = DateTime.Now.AddMinutes(-15),
                    Incoming = true,
                },
                new Message
                {
                    Id = 2,
                    ConversationId = conversationId,
                    UserId = MyUserID,
                    Text = "Eugene!",
                    Date = DateTime.Now.AddMinutes(-10),
                    Incoming = false,
                },
                new Message
                {
                    Id = 3,
                    ConversationId = conversationId,
                    UserId = 2,
                    Text = "Eugene Eugene??",
                    Date = DateTime.Now.AddMinutes(-5),
                    Incoming = true,
                },
                new Message
                {
                    Id = 4,
                    ConversationId = conversationId,
                    UserId = MyUserID,
                    Text = "Eugene Eugene Eugene!!!",
                    Date = DateTime.Now,
                    Incoming = false,
                },
                    }
                    );
                    break;

                case 4:
                    for (int i = 0; i < 30; i++)
                    {
                        messageList.AddRange(
                                            new[]
                                            {
                new Message
                {
                    Id = 1,
                    ConversationId = conversationId,
                    UserId = 2,
                    Text = "Previous message is a lie.",
                    Date = DateTime.Now.AddMinutes(-15),
                    Incoming = true,
                },
                new Message
                {
                    Id = 2,
                    ConversationId = conversationId,
                    UserId = MyUserID,
                    Text = "Previous message is a lie.",
                    Date = DateTime.Now.AddMinutes(-15),
                    Incoming = false,
                }
                                            }
                                            );
                    }
                    break;

                default:
                    messageList.AddRange(
                    new[]
                    {
                new Message
                {
                    Id = 1,
                    ConversationId = conversationId,
                    UserId = 2,
                    Text = "Hi",
                    Date = DateTime.Now.AddMinutes(-15),
                    Incoming = true,
                },
                new Message
                {
                    Id = 2,
                    ConversationId = conversationId,
                    UserId = MyUserID,
                    Text = "Hi, how are you doing",
                    Date = DateTime.Now.AddMinutes(-10),
                    Incoming = false,
                },
                new Message
                {
                    Id = 3,
                    ConversationId = conversationId,
                    UserId = 2,
                    Text = "Pretty well, still coding C#",
                    Date = DateTime.Now.AddMinutes(-5),
                    Incoming = true,
                },
                new Message
                {
                    Id = 4,
                    ConversationId = conversationId,
                    UserId = MyUserID,
                    Text = "Same same, its great I like C#",
                    Date = DateTime.Now,
                    Incoming = false,
                },
                    }
                    );
                    break;
            }
            return new ObservableCollection<Message>(messageList);
        }

        public async Task<Message> SendMessage(Message message)
        {
            await Sleep();
            return message;
        }




    }
}
