﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.Pages.Navigation_page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conteudo02 : ContentPage
    {
        public Conteudo02()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var pilha = Navigation.NavigationStack;
            Navigation.PopAsync();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Conteudo03());
        }
    }
}