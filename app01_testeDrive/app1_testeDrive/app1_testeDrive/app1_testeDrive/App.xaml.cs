using app1_testeDrive.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app1_testeDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Aqui chama a pagina de navegação,Está encapsulando a listagemviiew
            MainPage = new NavigationPage(new ListagemView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
