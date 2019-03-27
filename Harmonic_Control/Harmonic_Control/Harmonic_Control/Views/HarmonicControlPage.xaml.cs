using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Harmonic_Control.Views;
using System.Diagnostics;
using System.Timers;

namespace Harmonic_Control.Views
{
    public partial class HarmonicControlPage : ContentPage
    {
        List<String> itemListControlName;
        List<String> itemListbuttonColor;
        List<String> itemListbuttonText;
        List<String> itemListbuttonTextColor;
        List<String> itemListSetTimeText;

        Timer aTimer;
        ObservableCollection<HamonicControlItem> listControl = new ObservableCollection<HamonicControlItem>();

        HamonicControlItem controlItem = new HamonicControlItem();
        public HarmonicControlPage()
        {

            InitializeComponent();
            EmployeeListPage();
            AddItemControl();
            OnButton_CheckConnectAll();
            SetTimer();
        }
        public int GetStatusCheck() {
            return controlItem.GetStatusCheck();
        }
        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(20000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            String itemName = listControl[0].ItemControlName;
            controlItem.HamonicItemCheckStatus(itemName, HamonicControlItem.CHECKSTATUS_COMMAND);
            int status = GetStatusCheck();
            SetItemControl(0, status);

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
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "1", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText=HamonicControlItem.Button_Set_Time_Text});
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "2", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "3", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "4", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "5", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "6", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "7", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "8", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "9", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "10", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "11", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "12", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "13", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "14", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "15", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });
            listControl.Add(new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "16", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text });

        }
        private void SetItemControl(int index, int status) {
            switch (status) {
                case HamonicControlItem.HARMONIC_NOT_CONNNECT:
                    listControl[index] = new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + (1+index).ToString(), ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text };
                    break;
                case HamonicControlItem.HARMONIC_ON:
                    listControl[index] = new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + (1 + index).ToString(), ButtonColor = HamonicControlItem.Button_Color_On, ButtonText = HamonicControlItem.Button_On, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text };

                    break;
                case HamonicControlItem.HARMONIC_OFF:
                    listControl[index] = new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + (1 + index).ToString(), ButtonColor = HamonicControlItem.Button_Color_Off, ButtonText = HamonicControlItem.Button_Color_Off, ButtonTextColor = HamonicControlItem.Button_Text_Color_OFF, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text };
                    break;
                default:
                    listControl[index] = new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + (1 + index).ToString(), ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text };
                    break;
          }
        }
        private void OnButton_ON_OFF_Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            SetStatusButton(button);
           // await label.RelRotateTo(360, 1000);
        }

        private async void SetHamonicTime(object sender, EventArgs args) {
            Button button = (Button)sender;
            String itemSetTimeName = ItemChoose(button);
            Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
            SetTime setTime = new SetTime(itemSetTimeName);
            await Navigation.PushModalAsync(new NavigationPage(setTime));
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
            // for (int i=0;i<= listControl.Count; i ++)
            {
                String itemName = listControl[0].ItemControlName;
                int resultCheckStatus = controlItem.HamonicItemCheckStatus(itemName, HamonicControlItem.CHECKSTATUS_COMMAND);
                switch (resultCheckStatus) {
                    case HamonicControlItem.HARMONIC_NOT_CONNNECT:
                        listControl[0] = new HamonicControlItem { ItemControlName= HamonicControlItem.ItemControlHeadName+"1", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON,ButtonSetTimeText=HamonicControlItem.Button_Set_Time_Text };
                        break;
                    case HamonicControlItem.HARMONIC_OFF:
                        listControl[0] = new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName +"1", ButtonColor = HamonicControlItem.Button_Color_Off, ButtonText = HamonicControlItem.Button_Off, ButtonTextColor = HamonicControlItem.Button_Text_Color_OFF, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text };
                        break;
                    case HamonicControlItem.HARMONIC_ON:
                        listControl[0] = new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "1", ButtonColor = HamonicControlItem.Button_Color_On, ButtonText = HamonicControlItem.Button_On, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text };
                        break;
                    default:
                        listControl[0] = new HamonicControlItem { ItemControlName = HamonicControlItem.ItemControlHeadName + "1", ButtonColor = HamonicControlItem.Button_Color_Disconnect, ButtonText = HamonicControlItem.Button_No_Connect, ButtonTextColor = HamonicControlItem.Button_Text_Color_ON, ButtonSetTimeText = HamonicControlItem.Button_Set_Time_Text };
                        break;
                }       
            }

            return;

        }

        private void SetStatusButton(Button button)
        {
            StackLayout stackLayoutParent = (StackLayout)button.Parent;
            Button buttonTime = (Button)stackLayoutParent.Children[3];
            if (button.Text == HamonicControlItem.Button_On)
            {

                int resultControl = controlItem.HamonicItemSetting(ItemChoose(button),HamonicControlItem.OFF_COMMAND);

                if (resultControl==HamonicControlItem.HARMONIC_ON)
                {
                    button.Text = HamonicControlItem.Button_On;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_On);
                    buttonTime.BackgroundColor= Color.FromHex(HamonicControlItem.Button_Color_On);
                }
                else if (resultControl == HamonicControlItem.HARMONIC_OFF)
                {
                    button.Text = HamonicControlItem.Button_Off;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Off);
                    buttonTime.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Off);

                }
                else
                {
                    button.Text = HamonicControlItem.Button_No_Connect;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Disconnect);
                    buttonTime.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Disconnect);
                }

            }
            else
            {              
                int resultControl = controlItem.HamonicItemSetting(ItemChoose(button), HamonicControlItem.ON_COMMAND);
                if (resultControl == HamonicControlItem.HARMONIC_ON)
                {
                    button.Text = HamonicControlItem.Button_On;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_On);
                    buttonTime.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_On);

                }
                else if (resultControl == HamonicControlItem.HARMONIC_OFF)
                {
                    button.Text = HamonicControlItem.Button_Off;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Off);
                    buttonTime.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Off);
                }
                else {
                    button.Text = HamonicControlItem.Button_No_Connect;
                    button.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Disconnect);
                    buttonTime.BackgroundColor = Color.FromHex(HamonicControlItem.Button_Color_Disconnect);
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
