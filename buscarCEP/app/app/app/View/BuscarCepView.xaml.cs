using app.Servico;
using app.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app.View
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class BuscarCepView : ContentPage
    {
        public BuscarCepViewModel ViewModel { get; set; }
        ViaCEPServico viaCepServico;
        public BuscarCepView()
        {
            //Executa a mainPage.xaml
            InitializeComponent();

            //this.ViewModel = new BuscarCepViewModel();
            //this.BindingContext = this.ViewModel;
            //this.BindingContext = new BuscarCepViewModel();

            //Paginas
            //Layouts
            //View - Controles que vai interagir com o usuário
            viaCepServico = new ViaCEPServico();
            buscar.Clicked += BuscarCEP;
        }

        public async void BuscarCEP(object sender, EventArgs args)
        {
            //Endereco end = new Endereco();
            //string teste = cep.Text;
            if (cep.Text != null)
            {
                string CEP = cep.Text.Trim();
                if (isValidCEP(CEP))
                {
                    try
                    {
                        Endereco end = await viaCepServico.BuscarEnderecoViaCep(CEP);

                        if(end != null)
                        {
                            resultado.Text = string.Format("Endereco: {0}, {1} {2} {3}", end.localidade, end.uf, end.logradouro, end.bairro);
                        }
                        else
                        {
                            DisplayAlert("ERRO", "Endereço não encontrato para o cep: " + cep, "OK"); 
                        }

                    }
                    catch(Exception e)
                    {
                        DisplayAlert("Erro Critico", e.Message, "OK");
                    }
                    
                }
            }
            else
            {
                DisplayAlert("ERRO", "CEP Inválido, CEP deve conter 8 caracteres", "Voltar");
            }
                       
        }



        private bool isValidCEP(string CEP)
        {
            bool valid = true;

            if (CEP.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido, CEP deve conter 8 caracteres", "Voltar");
                valid = false;
            }
            int NovoCep = 0;
            
            //tente converter
            //Passamos um parametro e um resultado caso a conversao tenha sido um sucesso
            //Caso tenha sido um sucesso o out devolve um inteiro
            if(!int.TryParse(CEP, out NovoCep))
            {
                valid = false;
                DisplayAlert("ERRO", "CEP Inválido, CEP deve ser composto por números", "Voltar");
            }

            return valid;
        }
    }
}
