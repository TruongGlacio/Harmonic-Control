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
            aTimer = new Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            String itemName = listControl[0].ItemControlName;
            controlItem.HamonicItemCheckStatus(itemName, ConstDefine.CHECKSTATUS_COMMAND);
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
            for(int i = 1; i < ConstDefine.ITEMCONTROL_LIST.Count; i++)
            {
                listControl.Add(new HamonicControlItem { ItemControlName = ConstDefine.ITEMCONTROL_LIST[i], ButtonColor = ConstDefine.Button_Color_Disconnect, ButtonText = ConstDefine.Button_No_Connect, ButtonTextColor = ConstDefine.Button_Text_Color_ON, ButtonSetTimeText = ConstDefine.Button_Set_Time_Text });
            }
        }
        private void SetItemControl(int index, int status) {
            switch (status) {
                case ConstDefine.HARMONIC_NOT_CONNNECT:
                    listControl[index] = new HamonicControlItem { ItemControlName = ConstDefine.ITEMCONTROL_LIST[index+1], ButtonColor = ConstDefine.Button_Color_Disconnect, ButtonText = ConstDefine.Button_No_Connect, ButtonTextColor = ConstDefine.Button_Text_Color_ON, ButtonSetTimeText = ConstDefine.Button_Set_Time_Text };
                    break;
                case ConstDefine.HARMONIC_ON:
                    listControl[index] = new HamonicControlItem { ItemControlName = ConstDefine.ITEMCONTROL_LIST[index+1], ButtonColor = ConstDefine.Button_Color_On, ButtonText = ConstDefine.Button_On, ButtonTextColor = ConstDefine.Button_Text_Color_ON, ButtonSetTimeText = ConstDefine.Button_Set_Time_Text };

                    break;
                case ConstDefine.HARMONIC_OFF:
                    listControl[index] = new HamonicControlItem { ItemControlName = ConstDefine.ITEMCONTROL_LIST[index+1], ButtonColor = ConstDefine.Button_Color_Off, ButtonText = ConstDefine.Button_Off, ButtonTextColor = ConstDefine.Button_Text_Color_OFF, ButtonSetTimeText = ConstDefine.Button_Set_Time_Text };
                    break;
                default:
                    listControl[index] = new HamonicControlItem { ItemControlName = ConstDefine.ITEMCONTROL_LIST[index+1], ButtonColor = ConstDefine.Button_Color_Disconnect, ButtonText = ConstDefine.Button_No_Connect, ButtonTextColor = ConstDefine.Button_Text_Color_ON, ButtonSetTimeText = ConstDefine.Button_Set_Time_Text };
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
             for (int i=1;i<= ConstDefine.ITEMCONTROL_LIST.Count-1; i ++)
            {
                String itemName = listControl[i-1].ItemControlName;
                int resultCheckStatus = controlItem.HamonicItemCheckStatus(itemName, ConstDefine.CHECKSTATUS_COMMAND);
                switch (resultCheckStatus) {
                    case ConstDefine.HARMONIC_NOT_CONNNECT:
                        listControl[i-1] = new HamonicControlItem { ItemControlName= ConstDefine.ITEMCONTROL_LIST[i], ButtonColor = ConstDefine.Button_Color_Disconnect, ButtonText = ConstDefine.Button_No_Connect, ButtonTextColor = ConstDefine.Button_Text_Color_ON,ButtonSetTimeText= ConstDefine.Button_Set_Time_Text };
                        break;
                    case ConstDefine.HARMONIC_OFF:
                        listControl[i-1] = new HamonicControlItem { ItemControlName = ConstDefine.ITEMCONTROL_LIST[i], ButtonColor = ConstDefine.Button_Color_Off, ButtonText = ConstDefine.Button_Off, ButtonTextColor = ConstDefine.Button_Text_Color_OFF, ButtonSetTimeText = ConstDefine.Button_Set_Time_Text };
                        break;
                    case ConstDefine.HARMONIC_ON:
                        listControl[i-1] = new HamonicControlItem { ItemControlName = ConstDefine.ITEMCONTROL_LIST[i], ButtonColor = ConstDefine.Button_Color_On, ButtonText = ConstDefine.Button_On, ButtonTextColor = ConstDefine.Button_Text_Color_ON, ButtonSetTimeText = ConstDefine.Button_Set_Time_Text };
                        break;
                    default:
                        listControl[i-1] = new HamonicControlItem { ItemControlName = ConstDefine.ITEMCONTROL_LIST[i], ButtonColor = ConstDefine.Button_Color_Disconnect, ButtonText = ConstDefine.Button_No_Connect, ButtonTextColor = ConstDefine.Button_Text_Color_ON, ButtonSetTimeText = ConstDefine.Button_Set_Time_Text };
                        break;
                }       
            }

            return;

        }

        private void SetStatusButton(Button button)
        {
            StackLayout stackLayoutParent = (StackLayout)button.Parent;
            Button buttonTime = (Button)stackLayoutParent.Children[3];
            if (button.Text == ConstDefine.Button_On)
            {

                int resultControl = controlItem.HamonicItemSetting(ItemChoose(button), ConstDefine.OFF_COMMAND);

                //if (resultControl== ConstDefine.HARMONIC_ON)
                //{
                //    button.Text = ConstDefine.Button_On;
                //    button.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_On);
                //    buttonTime.BackgroundColor= Color.FromHex(ConstDefine.Button_Color_On);
                //}
                //else if (resultControl == ConstDefine.HARMONIC_OFF)
                //{
                //    button.Text = ConstDefine.Button_Off;
                //    button.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Off);
                //    buttonTime.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Off);

                //}
                //else
                //{
                //    button.Text = ConstDefine.Button_No_Connect;
                //    button.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Disconnect);
                //    buttonTime.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Disconnect);
                //}

            }
            else
            {              
                int resultControl = controlItem.HamonicItemSetting(ItemChoose(button), ConstDefine.ON_COMMAND);
                //if (resultControl == ConstDefine.HARMONIC_ON)
                //{
                //    button.Text = ConstDefine.Button_On;
                //    button.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_On);
                //    buttonTime.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_On);

                //}
                //else if (resultControl == ConstDefine.HARMONIC_OFF)
                //{
                //    button.Text = ConstDefine.Button_Off;
                //    button.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Off);
                //    buttonTime.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Off);
                //}
                //else {
                //    button.Text = ConstDefine.Button_No_Connect;
                //    button.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Disconnect);
                //    buttonTime.BackgroundColor = Color.FromHex(ConstDefine.Button_Color_Disconnect);
                //}

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
