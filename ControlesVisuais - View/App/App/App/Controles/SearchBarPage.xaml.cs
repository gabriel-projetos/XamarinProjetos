using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchBarPage : ContentPage
    {
        private List<string> empresas;
        public SearchBarPage()
        {
            InitializeComponent();

            empresas = new List<string>();
            empresas.Add("Microsoft");
            empresas.Add("Apple");
            empresas.Add("Sansung");
            empresas.Add("IBM");
            empresas.Add("Oracle");
            empresas.Add("SAP");
            empresas.Add("Uber");
            empresas.Add("TAM");
            empresas.Add("GOL");
            empresas.Add("Petrobras");
            empresas.Add("TOTVS");

            Preencher(empresas);
        }



        void Preencher(List<string> empresas)
        {
            ListResult.Children.Clear();
            foreach (var empresa in empresas)
            {
                ListResult.Children.Add(new Label { Text = empresa });
            }
        }

        

        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            //pega o elemento e verifica se o elemento contem o texto digitado na pesquisa
            var resultado = empresas.Where(elemento => elemento.ToLower().Contains(((SearchBar)sender).Text.ToLower())).ToList<string>();
            Preencher(resultado);
        }
    }
}