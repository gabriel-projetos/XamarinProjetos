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
    public partial class MasterDetailView : MasterDetailPage
    {
        //--------COMPONENTE COM A CAPACIDADE DE MUDAR DE PÁGINA -------//
        private readonly Usuario usuario;

        //Chamando master view
        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            //usuario que está sendo recebido no construtor
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
            this.Detail = new NavigationPage(new ListagemView(usuario));           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            AssinarMensagens();
        }

        private void AssinarMensagens()
        {
            /*<Objeto que está em anexo na mensagem>
		    * Instancia que está assinando, no caso a propria classe
		    */
            MessagingCenter.Subscribe<Usuario>(this, "MeusAgendamentos",
                (usuario) =>
                {
                    //instancia a pagina AgendamentosUsuario
                    this.Detail = new NavigationPage(
                        new AgendamentosUsuarioView());

                    //A propriedade IsPresented de MasterDetailPage indica se a página do menu (Master) deve ser exibida ou não.
                    this.IsPresented = false;
                });

            MessagingCenter.Subscribe<Usuario>(this, "NovoAgendamento",
                (usuario) =>
                {
                    this.Detail = new NavigationPage(
                        new ListagemView(usuario));

                    //A propriedade IsPresented de MasterDetailPage indica se a página do menu (Master) deve ser exibida ou não.
                    this.IsPresented = false;
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinaturas();
        }

        private void CancelarAssinaturas()
        {
            MessagingCenter.Unsubscribe<Usuario>(this, "MeusAgendamentos");
            MessagingCenter.Unsubscribe<Usuario>(this, "NovoAgendamento");
        }
    }
}