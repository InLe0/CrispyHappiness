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

        public ConversationDetail(int UserId)
        {
            
            InitializeComponent();
            var conversations2 = Task.Run(async () => await UserNameRetriever()).Result;
            Conversation conv = new Conversation();
            conv = conversations2[UserId-2];
            usernameLabel.Text = conv.Username;
            RetrieveChat();
            PopulateChat();
        }
        public void RetrieveChat()
        {
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
            }
        }
        public async Task<Conversation[]> UserNameRetriever()
        {
            var conversations2 = await totallyLegitimateWebService.GetConversations(1);

            return conversations2;
        }
        public async Task<ObservableCollection<Message>> TaskRetriever()
        {
            var Messages2 = await totallyLegitimateWebService.GetMessages(1);
            return Messages2;
        }

        private void userDetail_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserDetail());
        }
    }
}