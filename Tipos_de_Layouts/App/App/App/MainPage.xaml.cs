using App.Layouts.Absolut;
using App.Layouts.Grid;
using App.Layouts.Relative;
using App.Layouts.Scroll;
using App.Layouts.Stack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /* IMPLEMENTAR COMMAND PARA TROCAR DE PÁGINA */
        private void GoPaginaStack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StackPage());
        }

        private void GoPaginaGrid(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GridPage());
        }

        private void GoPaginaAbsolut(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AbsolutPage());
        }

        private void GoPaginaScroll(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScrollPage());
        }

        private void GoPaginaRelative(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RelativePage());
        }
    }
}
