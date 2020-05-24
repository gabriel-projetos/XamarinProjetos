using app.Tipo_pagina.Navigation;
using app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app.Tipo_pagina.Carousel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoPage3 : ContentPage
    {
        public TipoPage3()
        {
            InitializeComponent();

            this.BindingContext = new TipoPage3ViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Pagina1>(this, "MudarPagina");
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Pagina1>(this, "MudarPagina", (msg) =>
            {
                //Cria uma nova mainPage para poder aplicar o navigationPage
                //As proriedades colocadas aqui reflente em toda a pilha de navegação por conta de estarem no pai
                //App.Current.MainPage = new NavigationPage(new Pagina1()) { BarBackgroundColor = Color.Blue } ;
                App.Current.MainPage = new Tabbed.Abas();

                //Para adicionar uma pagina na pilha caso a anterior seja do tipo NavigationPage
                //Nagivation.PushAsync(new pagina1());
            });
        }

        


    }
}