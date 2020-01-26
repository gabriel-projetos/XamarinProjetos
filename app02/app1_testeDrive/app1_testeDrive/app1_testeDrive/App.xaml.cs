using app1_testeDrive.Models;
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

            /* Aqui define qual a view de entrada, a tela inicial da aplicação
             * Aqui chama a pilha de navegação, Começando pela tela inicial ListagemView
             * MainPage = new NavigationPage(new ListagemView()); */

            //Aqui define qual a view de entrada, a tela inicial da aplicação
            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            //Quando estiver iniciando
            //Subscribe: Captura da mensagem
            //<Tipo de objeto que esta sendo passando na mensagem>
            //<Usuarios está sendo capturado>
            //this: pq é a propria classe app que está capturando a msg
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin",
                //Expressão lambda recebe de um usuario
                (usuario) => 
                {
                    //Tratar o procedimento qnd a msg for capturada
                    //Aqui trocaremos a mainPage para dps do login abrir ListagemView
                    //MainPage = new NavigationPage(new ListagemView());

                    MainPage = new MasterDetailView(usuario);
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
