using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app.Tipo_pagina.Tabbed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Abas : TabbedPage
    {
        public Abas()
        {
            InitializeComponent();

            //Adicionar uma nova aba na tabbedPage
            Children.Add(new NavigationPage(new Tipo_pagina.Navigation.Pagina1()) { Title = "Item 3" });
        }
    }
}