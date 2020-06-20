using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()       
        {
            InitializeComponent();
        }

        private void GoPaginaPerfil1(object sender, EventArgs e)
        {
            Detail = new Pages.Perfil_1();
            this.IsPresented = false;
        }

        private void GoPaginaXamarin_Clicked(object sender, EventArgs e)
        {
            Detail = new Pages.Xamarin();
            this.IsPresented = false;
        }
    }
}