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
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
            
        //Construtor
        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            //Chamada do construtor
            this.BindingContext = new DetalheViewModel(veiculo);

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            //this:Referencia de quem está assinando, o proprio codebehind no caso
            MessagingCenter.Subscribe<Veiculo>(this, "Proximo", (msg) => 
            {
                //msg contem o veiculo que está sendo escolhido durante o fluxo da app
                //Vai colocar mais uma pagina na pilha de navegação 
                //Só é executado qnd uma msg do tipo "Proximo" for enviada
                Navigation.PushAsync(new AgendamentoView(msg));
            });

            //ViewModel 
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //this:Referencia de quem está cancelando a assinado, o proprio codebehind no caso
            MessagingCenter.Unsubscribe<Veiculo>(this, "Proximo");
        }
    }
}