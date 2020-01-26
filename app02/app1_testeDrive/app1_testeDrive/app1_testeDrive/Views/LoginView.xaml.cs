using app1_testeDrive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app1_testeDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        //Capturara a mensagem
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Tipo da mensagem, quem está assinando this pq é a propria classe
            //Nome do tipo de mensagem
            //ação qnd a mensagem é recebida no caso o erro
            MessagingCenter.Subscribe<LoginExeception>(this, "FalhaLogin",
                async (exe) =>
                {
                    await DisplayAlert("Login", exe.Message, "OK");
                });
        }

        //Cancelar assim que a view deixa de aparecer
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<LoginExeception>(this, "FalhaLogin");
        }

    }
}