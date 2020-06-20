using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBarPage : ContentPage
    {
        public double Carregamento { get; set; }
        public ProgressBarPage()
        {
            InitializeComponent();
            BindingContext = new ProgressBarPageModel(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<ProgressBarPageModel>(this, "CarregarProgress", async (msg) =>
            {
                progresso.ProgressColor = Color.Red;
                await progresso.ProgressTo(1, 5000, Easing.Linear);               
                if (progresso.Progress == 1)
                {
                    await DisplayAlert("Sucesso", "Carregado com sucesso", "OK");
                };


            });

            MessagingCenter.Subscribe<ProgressBarPageModel>(this, "DescarregarProgress", async (msg) =>
            {
                progresso.ProgressColor = Color.Yellow;
                await progresso.ProgressTo(0, 5000, Easing.Linear);
                if (progresso.Progress == 0) 
                {
                    await DisplayAlert("Sucesso", "Descarregado com sucesso", "OK");
                };
            });

        }

        private void CancelarMensagens()
        {
            MessagingCenter.Unsubscribe<ProgressBarPageModel>(this, "CarregarProgress");
            MessagingCenter.Unsubscribe<ProgressBarPageModel>(this, "DescarregarProgress");
        }
    }
}