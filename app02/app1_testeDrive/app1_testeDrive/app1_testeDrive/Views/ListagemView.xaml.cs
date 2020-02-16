using app1_testeDrive.Models;
using app1_testeDrive.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app1_testeDrive.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class ListagemView : ContentPage
    { 
        //ViewModel contem uma instancia de ListagemViewModel
        public ListagemViewModel ViewModel { get; set; }

        readonly Usuario usuario;
        public ListagemView(Usuario usuario)
        {
            InitializeComponent();

            //Mudando o contexto do Binding para passar a ser a ViewModel envez do CodeBehind
            this.ViewModel = new ListagemViewModel();
            this.usuario = usuario;
            this.BindingContext = this.ViewModel;

            //Muda o contexto, defini o contexto de binding da página no final do construtor da página.
            //this.BindingContext = this;
        }

        //Ao aparecer
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();

            await this.ViewModel.GetVeiculos();
        }

        private void AssinarMensagens()
        {
            //Tipo de argumento que está sendo enviado, qual o conteudo da msg
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                (veiculo) =>
                {
                    /*msg = Execução para navegar para a proxima pg, expressão lambda
                    Executa qnt a msg for recebida, qnt for capturada pela view*/

                    //qnd toca em um item na lista, o úsuario é levado para a proxima pagina
                    //Empilha as paginas, Assincrono retorna o comando imediatamente, ñ bloqueia
                    Navigation.PushAsync(new DetalheView(veiculo, usuario));
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de veículos", "OK");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinatura();
        }

        private void CancelarAssinatura()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}
