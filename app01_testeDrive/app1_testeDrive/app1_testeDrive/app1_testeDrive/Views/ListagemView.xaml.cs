using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app1_testeDrive.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado
        {
            get { return string.Format("R$ {0}", Preco); }
        }
        //public decimal Teste { get; set; }
    }
    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemView()
        {
            InitializeComponent();

            //This significa referencia
            this.Veiculos = new List<Veiculo>()
            {
                new Veiculo {Nome = "Azera V6", Preco = 60000, /*Teste = 4*/},
                new Veiculo {Nome = "Fiesta 2.0", Preco = 50000},
                new Veiculo {Nome = "HB20 S", Preco = 40000},

            };
            //Muda o contexto, defini o contexto de binding da página no final do construtor da página.
            this.BindingContext = this;
        }

        private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //Converte o objeto no veiculo
            var veiculo = (Veiculo)e.Item;

            /* DisplayAlert("Teste Drive", string.Format("Você tocou no modelo: {0}, Que custa" +
                ": {1} ",veiculo.Nome, veiculo.PrecoFormatado), "SAIR"); */

            //Empilha as paginas, Assincrono retorna o comando imediatamente, ñ bloqueia
            Navigation.PushAsync(new DetalheView(veiculo));

        }
    }
}
