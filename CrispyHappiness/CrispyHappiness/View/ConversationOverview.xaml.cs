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
            for (int k = 0; k < 30; k++)
            {
                IdList.Add(k);
            }
            int i = 0;
            foreach (int ID in IdList)
            {
                button = new Button();
                Grid dynGrid = new Grid();
                dynGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
                dynGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
                dynGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });

                StackLayout dynStackImg = new StackLayout();
                ImageButton imgButt = new ImageButton();
                imgButt.Clicked += ImgButt_Clicked;
                imgButt.Source = "settingscogwheelpngicon651309.png";
                dynStackImg.Children.Add(imgButt);


                Grid.SetRow(dynStackImg, 0);
                Grid.SetColumn(dynStackImg, 0);
                dynGrid.Children.Add(dynStackImg);

                StackLayout dynStackTxt = new StackLayout();
                Label labelName = new Label();
                labelName.Text = "name";
                Label labelLastSext = new Label();
                labelLastSext.Text = "none";
                dynStackTxt.Children.Add(labelName);
                dynStackTxt.Children.Add(labelLastSext);

                Grid.SetRow(dynStackTxt, 0);
                Grid.SetColumn(dynStackTxt, 1);
                dynGrid.Children.Add(dynStackTxt);

                scrollyStack.Children.Add(dynGrid);
                i++;
            }
        }

        private void ImgButt_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConversationDetail());
        }

        private void Setting_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }
    }
}