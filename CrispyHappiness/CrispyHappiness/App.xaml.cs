
using CrispyHappiness.View;

using System;

using Xamarin.Forms;



namespace CrispyHappiness
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
            
            
        }
       
      

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
