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
    public partial class ConversationDetail : ContentPage
    {
        public ConversationDetail()
        {
            InitializeComponent();
        }
        public void RetrieveChats()
        {
        
        }

        public void PopulateChat()
        { 
        
        }
        private void userDetail_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UserDetail());
        }
    }
}