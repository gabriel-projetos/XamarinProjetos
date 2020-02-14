using GerenciadorNotas.Models;
using GerenciadorNotas.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GerenciadorNotas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();
            //BindingContext: A partir de qual objeto ela deve pegar as propriedades para montar o binding
            this.BindingContext = new MenuViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<MeuCadastroView>(this, "MeuCadastro", (msg) =>
            {
                Navigation.PushAsync(new MeuCadastroView());
            });

            MessagingCenter.Subscribe<DadosCursoView>(this, "DadosCurso", (msg) =>
            {
                //Vai colocar mais uma página na pilha de navegação
                Navigation.PushAsync(new DadosCursoView());
            });

            MessagingCenter.Subscribe<NotasFaltasView>(this, "NotasFaltas", (msg) =>
            {
                Navigation.PushAsync(new NotasFaltasView());
            });

            MessagingCenter.Subscribe<IntegralizacaoView>(this, "Integralizacao", (msg) =>
            {
                Navigation.PushAsync(new IntegralizacaoView());
            });

            
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<MeuCadastroView>(this, "MeuCadastro");
            MessagingCenter.Unsubscribe<DadosCursoView>(this, "DadosCurso");
            MessagingCenter.Unsubscribe<NotasFaltasView>(this, "NotasFaltas");
            MessagingCenter.Unsubscribe<IntegralizacaoView>(this, "Integralizacao");
        }
    }
}