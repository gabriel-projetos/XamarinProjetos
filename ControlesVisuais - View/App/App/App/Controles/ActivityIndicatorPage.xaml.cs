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
    public partial class ActivityIndicatorPage : ContentPage
    {
        public ActivityIndicatorPage()
        {
            InitializeComponent();
           
        }

        private void Ativar_Clicked(object sender, EventArgs e)
        {
            Activity.IsRunning = true;
        }

        private void Desativar_Clicked(object sender, EventArgs e)
        {
            Activity.IsRunning = false;
        }
    }
}