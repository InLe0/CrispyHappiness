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
    class LoginViewModel : ContentPage, INotifyPropertyChanged
    {
        FakeWebService totallyLegitimateWebService = new FakeWebService();
        User loggedUser;
        string username;
        string password;

        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            GetInHereCommand = new Command(GetInHere);
            
        }
        public Command GetInHereCommand { get; }
        async void GetInHere()
        {
            loggedUser = Task.Run(async () => await LoginHandler()).Result;
            Username = loggedUser.Password;
            Password = loggedUser.Username;

            await Navigation.PushAsync(new ConversationOverviewView(loggedUser));
        }

        public String Username {
            get { return username; }
            set { username = value; OnPropertyChanged(); }
        }
        public String Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); }
        }

        public async Task<User> LoginHandler()
        {
            var user2 = await totallyLegitimateWebService.Login(username, password);
            return user2;
        }
    }
}
