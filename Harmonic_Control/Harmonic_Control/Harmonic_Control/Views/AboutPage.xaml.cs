using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Harmonic_Control.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
          //  var image = new Image { Source =ImageSource.FromResource("Logo.png") };
           // image.Source = ImageSource.FromResource("Source/Image/Logo.png");
           //ImageLogo = image;


        }
    }
}