using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();
            //ImageOne.IsLoading


            Image img = new Image();

            if(Device.RuntimePlatform == Device.UWP)
            {
                img.Source = ImageSource.FromFile("imagens/ic_launcher.png");
            }
            else
            {
                img.Source = ImageSource.FromFile("usb.png");
            }


            //Adicionando um filho ao stackLEAYOUT
            Fotos.Children.Add(img);
        }
    }
}