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
       Button button;
       List<int> IdList = new List<int>();
        public ConversationOverview()
        {
            InitializeComponent();
            for (int k = 0; k < 15; k++)
            {
                IdList.Add(k);
            }
            int i = 0;
            foreach (int ID in IdList)
            {
                button = new Button
                {
                    Text = "name",


                };
                conversationGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                conversationGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                Grid.SetRow(button, i);
                Grid.SetColumn(button, 0);
                i++;
                conversationGrid.Children.Add(button);
            }
        }
    }
}