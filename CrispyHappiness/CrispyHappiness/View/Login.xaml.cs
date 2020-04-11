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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

        }

        private void loginButton_Clicked(object sender, EventArgs e)
        {
           // if(userName.Text == "xouma77" && password.Text == "123")
            {
                Navigation.PushAsync(new ConversationOverview());
            }
        }


    }
}