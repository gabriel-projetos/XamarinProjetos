using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app.Tipo_pagina.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        public Master()
        {
            InitializeComponent();
        }
        //********************************** Propriedade Detail é onde fica o Conteudo *********************//
        private void MudaPagina1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Navigation.Pagina1());
        }

        private void MudaPagina2(object sender, EventArgs e)
        {
            Detail = new Navigation.Pagina2();
        }

        private void MudaPagina3(object sender, EventArgs e)
        {
            Detail = new Conteudo();
        }
    }
}