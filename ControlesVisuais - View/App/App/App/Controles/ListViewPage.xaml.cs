using App.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Controles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage : ContentPage
    {
        public ListViewPage()
        {
            InitializeComponent();

            //Vindo da api
            //ObservableCollection<Pessoa> pessoas  = Banco.GetPessoas();


            ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();

            pessoas.Add(new Pessoa { Nome = "Gabriel", Idade = "20" });
            pessoas.Add(new Pessoa { Nome = "Fernanda", Idade = "20" });
            pessoas.Add(new Pessoa { Nome = "Gabrielle", Idade = "20" });
            pessoas.Add(new Pessoa { Nome = "Cecilia", Idade = "20" });
            pessoas.Add(new Pessoa { Nome = "Eduardo", Idade = "20" });
            

            ListaPessoas.ItemsSource = pessoas;
        }
    }
}