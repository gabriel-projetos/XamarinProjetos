using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGallery.Pages.Navigation_page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Conteudo03 : ContentPage
    {
        public Conteudo03()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void Voltar(object sender, EventArgs e)
        {
            //Remove de maneira assíncrona o Page superior da pilha de navegação. 
            Navigation.PopAsync();
        }

        private void VoltarParaInicio(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void InserirPagePilha(object sender, EventArgs e)
        {
            //Inserir uma página antes da 3
            Navigation.InsertPageBefore(new Conteudo01(), this);

            //Podemos o usar  o NavigationStack
            //Navigation.InsertPageBefore(new Conteudo01(), Navigation.NavigationStack[2]);

            //Alterar o app
            //App.Current.MainPage = new Page();
        }

        private void RemoverPagePilha(object sender, EventArgs e)
        {
            //usado para Remover a página especificada da pilha de navegação.
            Navigation.RemovePage(this);
        }
    }
}