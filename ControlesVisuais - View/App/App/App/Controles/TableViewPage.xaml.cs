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
    public partial class TableViewPage : ContentPage
    {
        public TableViewPage()
        {
            InitializeComponent();
            Frequencia.ValueChanged += (object sender, ValueChangedEventArgs e) => 
            {
                Resultado.Text = Convert.ToInt32((e.NewValue)).ToString();
            };
            Frequencia.DragCompleted += (object sender, EventArgs e) => 
            {
                if(Frequencia.Value == 7)
                {
                    DisplayAlert("OK", "Completo", "OK");
                }
                
            };

            btn.Clicked += (object sender, EventArgs e) =>
            {
                DisplayAlert("ok", " clicado", "ok");
            };
        }
    }
}