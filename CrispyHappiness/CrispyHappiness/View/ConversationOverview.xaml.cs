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
        Button button;
        List<int> IdList = new List<int>();
        FakeWebService totallyLegitimateWebService = new FakeWebService();
        List<Conversation> conversations = new List<Conversation>();
        public ConversationOverview()
        {
            InitializeComponent();

            Conversation[] kon = new Conversation[3];
            TaskCaller();
            searchBar.Text = "Bamboozle";

            for (int k = 0; k < 30; k++)
            {
                IdList.Add(k);
            }
            int i = 0;
            searchBar.Text += conversations.Count().ToString();
            foreach (var item in conversations)
            {
                button = new Button();
                Grid dynGrid = new Grid();
                dynGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
                dynGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
                dynGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                StackLayout dynStackImg = new StackLayout();
                ImageButton imgButt = new ImageButton();
                imgButt.Clicked += ImgButt_Clicked;
                imgButt.Source = "settingscogwheelpngicon651309.png";
                dynStackImg.Children.Add(imgButt);


                Grid.SetRow(dynStackImg, 0);
                Grid.SetColumn(dynStackImg, 0);
                dynGrid.Children.Add(dynStackImg);

                StackLayout dynStackTxt = new StackLayout();
                Label labelName = new Label();
                labelName.Text = item.Username;
                Label labelLastSext = new Label();
                labelLastSext.Text = "none";
                dynStackTxt.Children.Add(labelName);
                dynStackTxt.Children.Add(labelLastSext);

                Grid.SetRow(dynStackTxt, 0);
                Grid.SetColumn(dynStackTxt, 1);
                dynGrid.Children.Add(dynStackTxt);

                scrollyStack.Children.Add(dynGrid);
                i++;
            }
        }

        public void TaskCaller()
        {
           var conversations2 = Task.Run(async () => await TaskRetriever()).Result;
            foreach (var item in conversations2)
            {
                conversations.Add(item);
                searchBar.Text += conversations.Count().ToString();
            }
        }
        public async Task<Conversation[]> TaskRetriever()
        {
            var conversations2 = await totallyLegitimateWebService.GetConversations(1);
            searchBar.Text = conversations2.Count().ToString();
            return conversations2;
        }

        private void ImgButt_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConversationDetail());
        }

        private void Setting_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }
    }
}