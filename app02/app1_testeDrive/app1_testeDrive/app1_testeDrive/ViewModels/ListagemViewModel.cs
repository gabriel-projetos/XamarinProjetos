using app1_testeDrive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app1_testeDrive.ViewModels
{

    public class ListagemViewModel : BaseViewModel
    {
                                        
        const string URL_GET_VEICULOS = "https://aluracar.herokuapp.com/";
        //Lista observavel pela view, para verificar se houve mudanças
        public ObservableCollection<Veiculo> Veiculos { get; set; }


        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        { 
            get 
            {
                return VeiculoSelecionado;
            }
            set
            {
                //Seta o valor do veiculo selecionado, conforme valor de entrada
                veiculoSelecionado = value;
                if (value != null)
                {
                    //Enviando uma msg para a view
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
                }

            }
        }

        private bool aguarde;
        public bool Aguarde
        {
            get { return aguarde; }
            set 
            { 
                aguarde = value;
                OnPropertyChanged();
            }
        }


        public ListagemViewModel()
        {
            //Lista Inicializada
            this.Veiculos = new ObservableCollection<Veiculo>();
        }


        public async Task GetVeiculos()
        {
            Aguarde = true;
            HttpClient cliente = new HttpClient();

            //Espere a tarefa ser concluida para continuar a execução do app da proxima linha
            //o resultado é uma string SERIALIZADA
            var resultado = await cliente.GetStringAsync(URL_GET_VEICULOS);

            //Para obter os objs do sistema, tem que DESEREALIZAR a string em um Array de objetos
            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            //ParaCada veiculoJson em veiculosJson
            foreach (var veiculoJson in veiculosJson)
            {
                //Alimentando a LISTA
                this.Veiculos.Add(new Veiculo
                {
                    Nome = veiculoJson.nome,
                    Preco = veiculoJson.preco
                });
            }

            Aguarde = false;
        }
            
    }

    //classe utilizada para transformar JSON em .NET
    class VeiculoJson
    {
        //Propriedade que estão vindo do Serviço Json
        public string nome { get; set; }
        public int preco { get; set; }

    }
}
