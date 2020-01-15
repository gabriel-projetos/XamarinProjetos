using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app1_testeDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            //Setando o titulo da pagina.
            this.Title = veiculo.Nome;
        }
    }
}