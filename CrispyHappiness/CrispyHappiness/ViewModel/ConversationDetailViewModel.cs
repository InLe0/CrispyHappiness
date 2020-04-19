using CrispyHappiness.Model;
using CrispyHappiness.View;
using CrispyHappiness.Webservices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrispyHappiness.ViewModel
{
    class ConversationDetailViewModel
    {
        FakeWebService totallyLegitimateWebService = new FakeWebService();
        List<Message> messages = new List<Message>();
        int selectedID;
        User loggedUser;

        //hard coded value for testing 
        public string userName;
        //need this to be public and some other shit could probably have the original string be public as well haven't tried that 
        //make sure that in the .xaml the Text="{Binding}" has the same variable name as the public string 
        public string Username
        {
            get { return userName; }
        }

        public ConversationDetailViewModel(INavigation navigation)
        {

        }
        public ConversationDetailViewModel(User user, int userID)
        {
            loggedUser = user;
            selectedID = userID;
        }
        public void RetrieveChat()
        {
            
            List<Conversation> conv = new List<Conversation>();
            var conversations2 = Task.Run(async () => await UserNameRetriever()).Result;
            foreach (var item in conversations2)
            {
                conv.Add(item);
            }


            userName = conv.Find(item => item.UserId == selectedID).Username;

            var Messages2 = Task.Run(async () => await TaskRetriever()).Result;
            foreach (var item in Messages2)
            {
                messages.Add(item);
            }
        }

          
            public async Task<Conversation[]> UserNameRetriever() 
            {
                var conversations2 = await totallyLegitimateWebService.GetConversations(loggedUser.Id);

                return conversations2;
            }
            public async Task<ObservableCollection<Message>> TaskRetriever()
            {
                var Messages2 = await totallyLegitimateWebService.GetMessages(selectedID);
                return Messages2;
            }
        }
    }

