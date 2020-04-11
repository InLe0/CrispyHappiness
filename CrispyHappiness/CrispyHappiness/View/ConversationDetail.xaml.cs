using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrispyHappiness.Webservices;
using CrispyHappiness.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace CrispyHappiness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationDetail : ContentPage
    {
        FakeWebService totallyLegitimateWebService = new FakeWebService();
        List<Message> messages = new List<Message>();
        int selectedID;
        User loggedUser;
        Label scrollTo;

        public ConversationDetail(User user, int userID)
        {
            InitializeComponent();

            loggedUser = user;
            selectedID = userID;
            
            RetrieveChat();
            PopulateChat();
            //LazyFingers();
        }
        public void LazyFingers()
        {
            //bigScroller.ScrollToAsync(scrollTo, ScrollToPosition.End, true);
            //bigScroller.ScrollToAsync(chatStack, ScrollToPosition.End, true);
            var lastChild = chatStack.Children.LastOrDefault();
            if (lastChild != null)
            { bigScroller.ScrollToAsync(lastChild, ScrollToPosition.MakeVisible, true); }
        }
        public void RetrieveChat()
        {
            List<Conversation> conv = new List<Conversation>();
            var conversations2 = Task.Run(async () => await UserNameRetriever()).Result;
            foreach (var item in conversations2)
            {
                conv.Add(item);
            }

            usernameLabel.Text = conv.Find(item => item.UserId == selectedID).Username;

            var Messages2 = Task.Run(async () => await TaskRetriever()).Result;
            foreach (var item in Messages2)
            {
                messages.Add(item);
            }
        }

        public void PopulateChat()
        {
            Label label;
            foreach (var item in messages)
            {
                label = new Label();
                label.Text = item.Text;
                if (item.Incoming)
                {
                    label.HorizontalOptions = LayoutOptions.End;
                    label.BackgroundColor = Color.Aqua;
                }
                else
                {
                    label.HorizontalOptions = LayoutOptions.Start;
                    label.BackgroundColor = Color.Bisque;
                }
                chatStack.Children.Add(label);
                scrollTo = label;
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

        private void userDetail_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserDetail());
        }
    }
}