using app1_testeDrive.Models;
using app1_testeDrive.ViewModels;
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
    public partial class MasterView : TabbedPage
    {
        //public MasterViewModel ViewModel { get; set; } 

        //Construtor 
        public MasterView(Usuario usuario)
        {
            InitializeComponent();
            //Construtor
            this.BindingContext = new MasterViewModel(usuario);
        }

        //Códgo que vai interceptar/assinar a mensagem  ao aparecer
        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();

            MessagingCenter.Subscribe<Usuario>(this, "SucessoSalvarUsuario",
                (usuario) =>
                {
                    //Corpo da action
                    //this.CurrentePage pq é a tabbedPage atual
                    this.CurrentPage = this.Children[0];
                });
        }

        //Codigo que vai cancelar a assinatura da msg ao dessaparecer
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarMensagens();
        }

        private void AssinarMensagens()
        {
            //Qual o tipo/classe que estou interceptando<Usuario>
            //This pq é a propria classe que esta assinando a msg
            //callback/Lambda que vai ser executado qnd a msg for interceptada
            MessagingCenter.Subscribe<Usuario>(this, "EditarPerfil",
                //usuario que esta sendo enviado junto com a mensagem
                (usuario) =>
                {
                    //Código que sera executado qnd o usuario clicar no botao

                    //this.CurrentePage pq é a tabbedPage atual
                    //recebe a segunda pagina de indice 1
                    //qnd clicar sera levado para a segunda pagina
                    this.CurrentPage = this.Children[1];
                });
        }

        private void CancelarMensagens()
        {
            //Qual o tipo/classe que estou interceptando<Usuario>
            //This pq é a propria classe que esta cancelando a msg
            //callback/Lambda que vai ser executado qnd a msg for interceptada
            MessagingCenter.Unsubscribe<Usuario>(this, "EditarPerfil");
            MessagingCenter.Unsubscribe<Usuario>(this, "SucessoSalvarPerfil");
        }
    }
}