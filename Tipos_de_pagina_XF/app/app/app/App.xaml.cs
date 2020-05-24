using app.Tipo_pagina.Carousel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new IntroduçãoApp();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
