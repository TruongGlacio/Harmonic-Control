using Harmonic_Control.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Harmonic_Control.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SetTime : ContentPage
	{
        private String itemName="";
		public SetTime ()
		{
			InitializeComponent ();
		}
        public SetTime(String itemName)
        {
            InitializeComponent();
            this.SetItemName(itemName);
        }
        public void SetItemName(String itemName) {
            this.itemName = itemName;
        }
        public String GetItemName()
        {
            return this.itemName;
        }
        private async void SetTimeByUser(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            StackLayout stackLayoutParent = (StackLayout)button.Parent;
            StackLayout stackLayout_Parent_parent =(StackLayout) stackLayoutParent.Parent;
            StackLayout stackLayout = (StackLayout)stackLayout_Parent_parent.Children[1];
            Editor editor = (Editor)stackLayout.Children[1];
            String hourString = editor.Text;
            if (float.TryParse(hourString,System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float hours))
            {
                if (hours <= 0 || hours >= 24)
                    Console.WriteLine("Type value not time format ");
                else
                {
                    HamonicSetTime hamonicSetTime = new HamonicSetTime();
                    int result= hamonicSetTime.SetTime(this.GetItemName(),hours);
                    if (result == HamonicControlItem.HARMONIC_SET_TIME_TRUE)
                    {
                        button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_On);
                        //MainPage RootPage = new MainPage();
                        //Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
                        //MenuPages.Add(id, new NavigationPage(harmonicControlPage));
                        await Navigation.PushModalAsync(new NavigationPage(new HarmonicControlPage()));
                    }
                    else
                    {
                        button.BackgroundColor = Color.FromHex( HamonicControlItem.Button_Color_Off);  
                    }

                }
            }
            else
            {
                button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Off);
                Console.WriteLine("Type value not number");
            }

        }
        private async void BackToMain(object sender, EventArgs args) {
            await Navigation.PushModalAsync(new NavigationPage(new HarmonicControlPage()));

        }

    }
}