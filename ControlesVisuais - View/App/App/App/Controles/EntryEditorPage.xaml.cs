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
    public partial class EntryEditorPage : ContentPage
    {
        public EntryEditorPage()
        {
            InitializeComponent();

            //Quando o campo é alterado
            TxtIdade.TextChanged += delegate (object sender, TextChangedEventArgs args)
            {
                Lbl_Duplicado.Text = args.NewTextValue;
            };

            //Texto completado
            TxtComentario.Completed += delegate (object sender, EventArgs args)
            {
                LblQntCaracteres.Text = TxtComentario.Text.Length.ToString();
            };
        }
    }
}