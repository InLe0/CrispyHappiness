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
    public partial class LoginView : ContentPage
    {
        FakeWebService totallyLegitimateWebService = new FakeWebService();
        User loggedUser;
        public LoginView()
        {
            InitializeComponent();

        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
            loggedUser = Task.Run(async () => await LoginHandler()).Result;


            Navigation.PushAsync(new ConversationOverviewView(loggedUser));
        }

        public async Task<User> LoginHandler()
        {
            var user2 = await totallyLegitimateWebService.Login(userName.Text, password.Text);
            return user2;
        }

    }
}