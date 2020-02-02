using app1_testeDrive.Models;
using app1_testeDrive.Services;
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
    public partial class AgendamentosUsuarioView : ContentPage
    {
        //readolny pq só será instanciada uma vez 
        readonly AgendamentosUsuarioViewModel _viewModel;

        public AgendamentosUsuarioView()
        {
            InitializeComponent();
            this._viewModel = new AgendamentosUsuarioViewModel();
            this.BindingContext = this._viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //<objeto que recebe a mensagem>
            //(instancia que está assinando)
            MessagingCenter.Subscribe<Agendamento>(this, "AgendamentoSelecionado", async (agendamento) =>
            {
                //Verifica se o agendamento não foi confirmado e então reenvia
                if (!agendamento.Confirmado)
                {
                    //Pedindo confirmação do usuario
                    var reenviar = await DisplayAlert("Reenviar", "Deseja reenviar o agendamento?", "sim", "não");

                    if (reenviar)
                    {
                        AgendamentoService agendamentoService = new AgendamentoService();
                        await agendamentoService.EnviarAgendamento(agendamento);

                        //assim que o agendamento for reenviado, a view será notificada e vai atualizar a lista da viewmodel
                        this._viewModel.AtualizarLista();

                    }
                }
            });

            //(Recebe uma instancia do agendamento)
            MessagingCenter.Subscribe<Agendamento>(this, "SucessoAgendamento",
                async (agendamento) =>
                {
                    await DisplayAlert("Reenviar", "Reenvio com sucesso", "ok");
                });

            MessagingCenter.Subscribe<Agendamento>(this, "FalhaAgendamento",
                async (agendamento) =>
                {
                    await DisplayAlert("Reenviar", "Falha ao reenviar!", "ok");
                });
        }

        //Ao dessaparecer
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<Agendamento>(this, "AgendamentoSelecionado");
            MessagingCenter.Unsubscribe<Agendamento>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<Agendamento>(this, "FalhaAgendamento"); 
        }
    }
}