using App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalendarioMesView : ContentPage
    {
        public CalendarioMesView()
        {
            InitializeComponent();
            this.BindingContext = new CalendarioMesViewModel(this, DateTime.Now.Month);
        }
    }
}