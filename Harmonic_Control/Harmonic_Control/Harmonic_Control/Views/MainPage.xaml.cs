using Harmonic_Control.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Harmonic_Control.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.MainPage, (NavigationPage)Detail);
        }
        public void CloseApplication()
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        public async Task NavigateFromMenu(int id)
        {
            HarmonicControlPage harmonicControlPage = new HarmonicControlPage();
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.MainPage:
                        MenuPages.Add(id, new NavigationPage(harmonicControlPage));
                        break;
                    case (int)MenuItemType.Checkconnect:
                        MenuPages.Add(id, new NavigationPage(harmonicControlPage));                   
                        harmonicControlPage.OnButton_CheckConnectAll();
                        //MenuPages.Add(id, new NavigationPage(new HarmonicControlPage()));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Exit:
                        CloseApplication();
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}