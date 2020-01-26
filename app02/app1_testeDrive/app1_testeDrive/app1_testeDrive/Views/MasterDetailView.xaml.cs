using app1_testeDrive.Models;
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
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario usuario;

        //Chamando master view
        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            //usuario que está sendo recebido no construtor
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
            
        }
    }
}