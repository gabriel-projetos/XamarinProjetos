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
    public partial class Modal : ContentPage
    {
        public Modal()
        {
            InitializeComponent();
        }

        private void fecharModal(object sender, EventArgs e)
        {
            //Quando chama com PushAsync para fechar é com PopAsync
            //Para voltar para a primeira pagina é PopToRootAsync ele destroi toda a pilha de navegação
            //Quando chama com PushModalAsync para Fechar o Modal é com PopModalAsync
            Navigation.PopModalAsync();
        }
    }
}