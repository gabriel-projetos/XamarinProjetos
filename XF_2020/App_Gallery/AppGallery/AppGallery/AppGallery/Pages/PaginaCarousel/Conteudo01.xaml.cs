using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.Pages.PaginaCarousel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conteudo01 : ContentPage
    {
        public Conteudo01()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var uriString = "whatsapp://send?phone=" + "5511963485531";

                if (!string.IsNullOrWhiteSpace("olá"))
                    uriString += "&text=" + "olá";

                Device.OpenUri(new Uri(uriString));

                //Launcher.CanOpenAsync(new Uri(uriString));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}