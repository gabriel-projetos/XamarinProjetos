
using app.Tipo_pagina.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace app.ViewModel
{
    public class TipoPage3ViewModel
    {
        public ICommand MudarPaginaCommand { get; set; }

        public TipoPage3ViewModel()
        {
            TrocaTelaCommand();
        }

        private void TrocaTelaCommand()
        {
            var pagina1 = new Pagina1();

            MudarPaginaCommand = new Command(() =>
            {
                MessagingCenter.Send<Pagina1>(pagina1, "MudarPagina");
            });
        }
    }
}
