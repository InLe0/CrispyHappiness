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
    public partial class ConversationOverview : ContentPage
    {
        public ConversationOverview()
        {
            InitializeComponent();
            foreach (int ID in IdList)
            {
                int i = 0;
                conversationGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                conversationGrid.SetRow(button, i++);
            }
        }
    }
}