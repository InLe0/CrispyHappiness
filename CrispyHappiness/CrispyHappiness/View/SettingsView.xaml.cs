using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrispyHappiness.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView : ContentPage
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private async void ChangeName_Clicked(object sender, EventArgs e)
        {
            string nameChange = await DisplayPromptAsync("How Shall We Know Thee?", "input your new name");
        }

        private async void changePassword_Clicked(object sender, EventArgs e)
        {
            // need to look at popups with several entries or just keep it at that and give up on password confirmation thingies
            string nameChange = await DisplayPromptAsync("PasswordChange", "input new password");
        }

        private void logout_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginView());
        }
    }
}