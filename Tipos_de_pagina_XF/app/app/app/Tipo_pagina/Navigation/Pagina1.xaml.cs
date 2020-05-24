using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app.Tipo_pagina.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagina1 : ContentPage
    {
        public Pagina1()
        {
            InitializeComponent();

        }

        private void MudarParaPagina2(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pagina2());
        }

        private void ChamarModal(object sender, EventArgs e)
        {
            //Adiciona uma pagina que não faz parte da pilha de navegação
            Navigation.PushModalAsync(new Modal());
        }

        private void ChamarMaster(object sender, EventArgs e)
        {
            App.Current.MainPage = new Master.Master();
        }
    }
}