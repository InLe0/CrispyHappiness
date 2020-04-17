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
    public partial class UserDetailView : ContentPage
    {
        public UserDetailView()
        {
            InitializeComponent();
        }

        private async void changeNames_Clicked(object sender, EventArgs e)
        {
            string nameChange = await DisplayPromptAsync("How Shall We Know Thee?", "input your new name");
        }

        private void NoIdeaWhatItIsSupposeToBeEvenWhenLookingAtThePrototype_Clicked(object sender, EventArgs e)
        {

        }

        private void SameAsLastOne_Clicked(object sender, EventArgs e)
        {

        }

        private void GroupCreationButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}