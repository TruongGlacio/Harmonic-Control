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
            CreatPickerContent();
		}
        public SetTime(String itemName)
        {
            InitializeComponent();
            this.SetItemName(itemName);
            CreatPickerContent();

        }
        public void SetItemName(String itemName) {
            this.itemName = itemName;
        }
        public String GetItemName()
        {
            return this.itemName;
        }
        private void CreatPickerContent()
        {
            // creat content item for Picker1
            picker_SetTime1.Items.Add("12h");
            picker_SetTime1.Items.Add("18h");
            picker_SetTime1.Items.Add("19h");
            picker_SetTime1.Items.Add("20h");
            picker_SetTime1.Items.Add("21h");
            picker_SetTime1.Items.Add("22h");
            picker_SetTime1.Items.Add("23h");
            picker_SetTime1.Items.Add("24h");
            // // creat content item for Picker2
            picker_SetTime2.Items.Add("12h");
            picker_SetTime2.Items.Add("18h");
            picker_SetTime2.Items.Add("19h");
            picker_SetTime2.Items.Add("20h");
            picker_SetTime2.Items.Add("21h");
            picker_SetTime2.Items.Add("22h");
            picker_SetTime2.Items.Add("23h");
            picker_SetTime2.Items.Add("24h");
            // creat content item for Picker3
            picker_SetTime3.Items.Add("12h");
            picker_SetTime3.Items.Add("18h");
            picker_SetTime3.Items.Add("19h");
            picker_SetTime3.Items.Add("20h");
            picker_SetTime3.Items.Add("21h");
            picker_SetTime3.Items.Add("22h");
            picker_SetTime3.Items.Add("23h");
            picker_SetTime3.Items.Add("24h");
            // creat content item for Picker4
            picker_SetTime4.Items.Add("12h");
            picker_SetTime4.Items.Add("18h");
            picker_SetTime4.Items.Add("19h");
            picker_SetTime4.Items.Add("20h");
            picker_SetTime4.Items.Add("21h");
            picker_SetTime4.Items.Add("22h");
            picker_SetTime4.Items.Add("23h");
            picker_SetTime4.Items.Add("24h");
            // creat content item for Picker5
            picker_SetTime5.Items.Add("12h");
            picker_SetTime5.Items.Add("18h");
            picker_SetTime5.Items.Add("19h");
            picker_SetTime5.Items.Add("20h");
            picker_SetTime5.Items.Add("21h");
            picker_SetTime5.Items.Add("22h");
            picker_SetTime5.Items.Add("23h");
            picker_SetTime5.Items.Add("24h");


        }
        private int GetTimeFromIndex(int index)
        {
            int Time = 18;
            switch (index)
            {
                case 0:
                    Time = 12;
                    break;
                case 1:
                    Time = 18;
                    break;
                case 2:
                    Time = 19;
                    break;
                case 3:
                    Time = 20;
                    break;
                case 4:
                    Time = 21;
                    break;
                case 5:
                    Time =22;
                    break;
                case 6:
                    Time = 23;
                    break;
                case 7:
                    Time = 24;
                    break;
                default:
                    break;
            }
            return Time;
        }
        private List<int> GetTimeSetting()
        {
            List<int> setTimeList = new List<int>();
            setTimeList.Add(GetTimeFromIndex(picker_SetTime1.SelectedIndex));
            setTimeList.Add(GetTimeFromIndex(picker_SetTime2.SelectedIndex));
            setTimeList.Add(GetTimeFromIndex(picker_SetTime3.SelectedIndex));
            setTimeList.Add(GetTimeFromIndex(picker_SetTime4.SelectedIndex));
            setTimeList.Add(GetTimeFromIndex(picker_SetTime5.SelectedIndex));
            return setTimeList;
        }
        private async void SetTimeByUser(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            List<int> SetTimeList = new List<int>();
            SetTimeList = GetTimeSetting();
            String hourStringList = string.Empty+SetTimeList[0];
            for (int i = 1; i < SetTimeList.Count; i++)
            {

                hourStringList += ","+SetTimeList[i];
            }
            HamonicSetTime hamonicSetTime = new HamonicSetTime();
            int result = hamonicSetTime.SetTime(this.GetItemName(), hourStringList);
            if (result == ConstDefine.HARMONIC_SET_TIME_TRUE)
            {
                button.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_On);
                //MainPage RootPage = new MainPage();
                //Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
                //MenuPages.Add(id, new NavigationPage(harmonicControlPage));
             }
            else
             {

                button.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Off);

            }
           

        }
        private async void BackToMain(object sender, EventArgs args) {
            await Navigation.PushModalAsync(new NavigationPage(new HarmonicControlPage()));

        }

    }
}