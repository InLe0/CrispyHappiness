using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrispyHappiness.Webservices;
using CrispyHappiness.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrispyHappiness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConversationOverview : ContentPage
    {
        FakeWebService totallyLegitimateWebService = new FakeWebService();
        List<Conversation> conversations = new List<Conversation>();
        User loggedUser;
        public ConversationOverview(User user)
        {
            InitializeComponent();

            loggedUser = user;
            RetrieveConversations();
            PopulateGrid();
        }

        public void RetrieveConversations()
        {
            var conversations2 = Task.Run(async () => await TaskRetriever()).Result;
            foreach (var item in conversations2)
            {
                conversations.Add(item);
            }
        }
        public void PopulateGrid()
        {
            Button button;
            foreach (var item in conversations)
            {
                button = new Button();
                Grid dynGrid = new Grid();
                dynGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
                dynGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
                dynGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                StackLayout dynStackImg = new StackLayout();
                ImageButts imgButt = new ImageButts();
                imgButt.Clicked += ImgButt_Clicked;
                imgButt.Source = item.Avatar;
                imgButt.userID = item.UserId;
                dynStackImg.Children.Add(imgButt);


                Grid.SetRow(dynStackImg, 0);
                Grid.SetColumn(dynStackImg, 0);
                dynGrid.Children.Add(dynStackImg);

                StackLayout dynStackTxt = new StackLayout();
                Label labelName = new Label();
                labelName.Text = item.Username;
                Label labelLastSext = new Label();
                labelLastSext.Text = item.LastMessage;
                dynStackTxt.Children.Add(labelName);
                dynStackTxt.Children.Add(labelLastSext);

                Grid.SetRow(dynStackTxt, 0);
                Grid.SetColumn(dynStackTxt, 1);
                dynGrid.Children.Add(dynStackTxt);

                scrollyStack.Children.Add(dynGrid);
            }
        }
        public async Task<Conversation[]> TaskRetriever()
        {
            var conversations2 = await totallyLegitimateWebService.GetConversations(loggedUser.Id);
            return conversations2;
        }

        private void ImgButt_Clicked(object sender, EventArgs e)
        {
            ImageButts imageButts = (ImageButts)sender; 
            Navigation.PushAsync(new ConversationDetail(loggedUser, imageButts.userID));
        }

        private void Setting_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }
    }
}