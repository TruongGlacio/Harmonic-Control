using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Harmonic_Control;
using System.Diagnostics;
namespace Harmonic_Control.Views
{
    public partial class HarmonicControlPage : ContentPage
    {
        ObservableCollection<HamonicControlItem> listControl = new ObservableCollection<HamonicControlItem>();

        HamonicControlItem controlItem = new HamonicControlItem();
        public HarmonicControlPage()
        {

            InitializeComponent();
            EmployeeListPage();
            AddItemControl();
            //monochrome will not appear in the list because it was added
            //after the list was populated.
            //   listView.ItemsSource.Add("monochrome");
        }
        public void EmployeeListPage()
        {
            //defined in XAML to follow
            ItemControlList.ItemsSource = listControl;
          //  Button_Floor6.WidthRequest = ContentPage.Width / 2;
      //      Button_Floor8.WidthRequest = ContentPage.Width / 2;
        }
        private void SetUpButtonFloor()
        {

        }
        private void AddItemControl()
        {
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "1", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON});
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "2", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "3", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "4", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "5", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "6", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "7", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "8", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "9", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "10", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "11", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "12", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "13", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "14", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "15", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "16", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON });

        }
        private void OnButton_ON_OFF_Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            SetStatusButton(button);
           // await label.RelRotateTo(360, 1000);
        }
        private void OnButton_Floor_Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (button == Button_Floor6)
            {

            }
            else if (button == Button_Floor8)
            {

            }          
        }
        public void OnButton_CheckConnectAll()
        {
            //ImageButton button = (ImageButton)sender;
            for (int i=0;i<= listControl.Count; i ++)
            {
                String itemName = listControl[i].ItemControlName;
                int resultCheckStatus = controlItem.HamonicItemCheckStatus(itemName, HamonicControlItem.CHECKSTATUS_COMMAND);
                switch (resultCheckStatus) {
                    case HamonicControlItem.HARMONIC_NOT_CONNNECT:
                        listControl[i] = new HamonicControlItem {ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON };
                        break;
                    case HamonicControlItem.HARMONIC_OFF:
                        listControl[i] = new HamonicControlItem { ButtonColor = HamonicControlItem.Button_Color_Off, ButtonText = HamonicControlItem.Button_Off, ButtonTextColor = HamonicControlItem.Button_Text_Color_OFF };
                        break;
                    case HamonicControlItem.HARMONIC_ON:
                        listControl[i] = new HamonicControlItem { ButtonColor = HamonicControlItem.Button_Color_On, ButtonText = HamonicControlItem.Button_On, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON };
                        break;
                    default:
                        listControl[i] = new HamonicControlItem { ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON };
                        break;

                }       
            }

            return;

        }

            private void SetStatusButton(Button button)
        {
            if (button.Text == HamonicControlItem.Button_On)
            {

                bool resultControl = controlItem.HamonicItemSetting(ItemChoose(button),HamonicControlItem.OFF_COMMAND);
                if (resultControl)
                {
                    button.Text = HamonicControlItem.Button_Off;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Off);
                }
                else
                {
                    button.Text = HamonicControlItem.Button_No_Connect;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Disconnect);
                }

            }
            else
            {              
                bool resultControl = controlItem.HamonicItemSetting(ItemChoose(button), HamonicControlItem.ON_COMMAND);
                if (resultControl)
                {
                    button.Text = HamonicControlItem.Button_On;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_On);
                }
                else
                {
                    button.Text = HamonicControlItem.Button_No_Connect;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Disconnect);
                }
            }
        }
        private string ItemChoose(Button button)
        {

            StackLayout stackLayoutParent = (StackLayout)button.Parent;
            Label label = (Label)stackLayoutParent.Children[2];

            string text = label.Text;
            Debug.WriteLine(text);
            return text;
            
        }
    }
}
