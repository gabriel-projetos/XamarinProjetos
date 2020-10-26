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
        public MainPage()
        {
            InitializeComponent();
        }

        private void MyControl_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Eu sou um evento", "Fui executado!", "Ok");
        }

        //Evento criado no MyControl
        //private void MyControl_Tapped(object sender, EventArgs e)
        //{
        //    DisplayAlert("Eu sou um evento", "Fui executado!", "Ok");
        //}
    }
}
