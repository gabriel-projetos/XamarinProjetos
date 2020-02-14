using GerenciadorNotas.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GerenciadorNotas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Aqui determina qual página é exibida primeiro quando inicia o app
            //Encapsula a pilha de navegação
            MainPage = new NavigationPage(new MenuView()); 
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
