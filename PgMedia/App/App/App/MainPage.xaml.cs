using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Precisamos habilitar permissão de ler e escrever no manisfest do android
            //Botão direito no projeto android -> Propriedades -> Android Manifest -> READ_EXTERNAL_STORAGE e WRITE_EXTERNAL_STORAGE

            btnFoto.Clicked += TirarFoto();
            private void async TirarFoto(object) { }
        }

    }
}
