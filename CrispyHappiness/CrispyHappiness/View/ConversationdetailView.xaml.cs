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
using CrispyHappiness.ViewModel;

namespace CrispyHappiness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationDetailView : ContentPage
    {
        FakeWebService totallyLegitimateWebService = new FakeWebService();
        List<Message> messages = new List<Message>();
        int selectedID;
        User loggedUser;
        Label scrollTo;
      
        public ConversationDetailView(User user, int userID)
        {
            InitializeComponent();
            loggedUser = user;
            selectedID = userID;
            //This what makes the binding work very important to have
            BindingContext = new ConversationDetailViewModel();



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
        public async void LazyFingers()
        {
            await bigScroller.ScrollToAsync(0, -200, true);
            //await bigScroller.ScrollToAsync(chatStack, ScrollToPosition.End, true);
            //var lastChild = chatStack.Children.LastOrDefault();
            //if (lastChild != null)
            //{ bigScroller.ScrollToAsync(lastChild, ScrollToPosition.MakeVisible, true); }
        }
        private void userDetail_Clicked(object sender, EventArgs e)
        {
            //avigation.PushAsync(new UserDetailView());
        }
    }
}