using LinqToAwait;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
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
            Button MyButton = new Button();
            MyButton.Text = "Eu sou diferente";
            MyButton.TextColor = Color.Coral;


            Container.Children.Add(MyButton);

            

          
        }

        

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            List<Pessoa> inputs = new List<Pessoa>()
            {
                new Pessoa { Idade = "5", Nome = 5},
                new Pessoa { Idade = "10", Nome = 3}
            };

            IEnumerable<string> results = await inputs.AsAsync()
                .FirstAsync(async data => await data.Idade == "5");
        }
    }
}
