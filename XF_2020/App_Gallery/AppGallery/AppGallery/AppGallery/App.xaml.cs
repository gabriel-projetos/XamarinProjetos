using AppGallery.Pages.Content_page;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new AppGallery.Pages.Navigation_page.Conteudo01());
            MainPage = new AppGallery.Pages.PaginaCarousel.Carousel();



            //Definir CaroulselPage
            //var caroulselPage = new CarouselPage();
            //caroulselPage.Children.Add(new AppGallery.Pages.PaginaCarousel.Conteudo01());
            //caroulselPage.Children.Add(new AppGallery.Pages.PaginaCarousel.Conteudo02());
            //caroulselPage.Children.Add(new AppGallery.Pages.PaginaCarousel.Conteudo03());

            //caroulselPage.CurrentPage = caroulselPage.Children[1];

            //MainPage = caroulselPage;
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
