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

        private void Button_Clicked(object sender, EventArgs e)
        {
            //MsgCenter a partir do loginviewmodel vai avisar a classe app.xaml
            //que existe uma nova MainPage que vai ser definida pela aplicação
            //A mensagem será recebida na classe app

            //<Tipo da mensagem>(Criando um Usuario)
            //Usuario clicou no btão entrar, é enviado a msg de SucessoLogin
            MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
        }
    }
}