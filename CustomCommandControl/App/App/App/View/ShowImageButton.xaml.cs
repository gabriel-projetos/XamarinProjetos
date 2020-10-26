using App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowImageButton : ContentPage
    {
        public ShowImageButton()
        {
            InitializeComponent();
            this.BindingContext = new ShowImageButtonViewModel();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Clicked", "Você clicou", "ok");
        }

        //void Handle_Clicked(object sender, EventArgs e)
        //{
        //    DisplayAlert("Clicked", "Você clicou", "ok");
        //}
    }
}