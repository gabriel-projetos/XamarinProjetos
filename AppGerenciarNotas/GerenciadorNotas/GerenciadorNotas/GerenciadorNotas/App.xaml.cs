using GerenciadorNotas.Models;
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
            MainPage = new LoginView(); 
        }

        protected override void OnStart()
        {
            //Recebendo a msg no momento do clique no botao entrar.
            MessagingCenter.Subscribe<Aluno>(this, "SucessoLogin", (usuario) =>
            {
                //Tratar a mensagem e iniciando uma nova MainPage a partir do Login
                MainPage = new NavigationPage(new MenuView());
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
