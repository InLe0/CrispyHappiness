using CrispyHappiness.Model;
using CrispyHappiness.View;
using CrispyHappiness.Webservices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrispyHappiness.ViewModel
{
    class ConversationOverviewViewModel : ContentPage, INotifyPropertyChanged
    {
        FakeWebService totallyLegitimateWebService = new FakeWebService();
        List<Conversation> conversations = new List<Conversation>();
        User loggedUser;
        public event PropertyChangedEventHandler PropertyChanged;
        public Command GetDemDetailsCommand { get; }
        public INavigation Navigation { get; set; }

        public ConversationOverviewViewModel(INavigation navigation)
        {
            this.Navigation = navigation;

        }



        async void GetDemDetails()
        {
            

            await Navigation.PushAsync(new ConversationDetailView());
        }

        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public async Task<Conversation[]> TaskRetriever()
        {
            var conversations2 = await totallyLegitimateWebService.GetConversations(loggedUser.Id);
            return conversations2;
        }

        private void ImgButt_Clicked(object sender, EventArgs e)
        {
            ImageButts imageButts = (ImageButts)sender;
            

        }

        private void Setting_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsView());
        }
        public void RetrieveConversations()
        {
            var conversations2 = Task.Run(async () => await TaskRetriever()).Result;
            foreach (var item in conversations2)
            {
                conversations.Add(item);
            }
        }
    }
}
