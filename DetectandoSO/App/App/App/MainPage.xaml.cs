using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        [Obsolete]
        public MainPage()
        {
            InitializeComponent();

            //Detectar o layout
            if(Device.Idiom == TargetIdiom.Phone)
            {
                DisplayAlert("ok", "Celular", "ok");
            };






            if (Device.RuntimePlatform == Device.iOS)
            {
                //Thickness = Margem
                Container.Margin = new Thickness(0, 10, 0, 0);
            }

            Thickness Margim = 0;  
            //Obsoleto
            Device.OnPlatform(iOS: () => 
            {
                Margim = new Thickness(0, 10, 0, 0);
            },
            Android: () => 
            {

            },
            WinPhone: () => 
            { 

            });

            //Para saber o tipo para usar no OnPlataform
            //Label lab;
            //lab.FontSize

            Container.Margin = Margim;
        }
    }
}
