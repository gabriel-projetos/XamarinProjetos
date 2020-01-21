using app1_testeDrive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace app1_testeDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {
                                             
        const string URL_POST_AGENDAMENTO = "https://aluracar.herokuapp.com/salvaragendamento";
        public Agendamento Agendamento { get; set; }

        public Veiculo Veiculo
        {
            get
            {
                return Agendamento.Veiculo;
            }
            set
            {
                Agendamento.Veiculo = value;
            }
        }
        public string Nome
        {
            get
            {
                return Agendamento.Nome;
            }
            set
            {
                Agendamento.Nome = value;
                OnPropertyChanged();
                //AgendarCommand é uma interface precisa ser convertido
                //Convertendo AgendarCommand para um command
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public string Fone
        {
            get
            {
                return Agendamento.Fone;
            }
            set
            {
                Agendamento.Fone = value;
                OnPropertyChanged();
                //AgendarCommand é uma interface precisa ser convertido
                //Convertendo AgendarCommand para um command
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public string Email
        {
            get
            {
                return Agendamento.Email;
            }
            set
            {
                Agendamento.Email = value;
                OnPropertyChanged();
                //AgendarCommand é uma interface precisa ser convertido
                //Convertendo AgendarCommand para um command
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }

        public DateTime DataAgendamento
        {
            get
            {
                return Agendamento.DataAgendamento;
            }
            set
            {
                Agendamento.DataAgendamento = value;
            }
        }

        public TimeSpan HoraAgendamento
        {
            get
            {
                return Agendamento.HoraAgendamento;
            }
            set
            {
                Agendamento.HoraAgendamento = value;
            }
        }

        public AgendamentoViewModel(Veiculo veiculo)
        {
            //Construtor
            this.Agendamento = new Agendamento();
            this.Agendamento.Veiculo = veiculo;

            AgendarCommand = new Command(() =>
            {
                //Enviar msg para a central de msg do xamarim do tipo agendamento
                //this pq a classe é o proprio emissor
                MessagingCenter.Send<Agendamento>(this.Agendamento
                    , "Agendamento");
            }, () =>
            {
                //Não pode ser uma string vazia no nome, fone e email.
                return !string.IsNullOrEmpty(this.Nome)
                && !string.IsNullOrEmpty(this.Fone)
                && !string.IsNullOrEmpty(this.Email);
            });
        }

        public ICommand AgendarCommand { get; set; }

        public async void SalvarAgendamento()
        {
            HttpClient cliente = new HttpClient();

            var dataHoraAgendamento = new DateTime(
                DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds
                );

            //Json a partir dos objetos.
            var Json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Fone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            });

            var conteudo = new StringContent(Json, Encoding.UTF8, "application/json");
            //Aguardar o resultado vindo do await para continuar a execução
            var resposta = await cliente.PostAsync(URL_POST_AGENDAMENTO, conteudo);

            //Se a requisição foi bem sucessida
            if (resposta.IsSuccessStatusCode)
                //this.agendamento(guarda os dados do agendamento)
                MessagingCenter.Send<Agendamento>(this.Agendamento, "SucessoAgendamento");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaAgendamento");
            //URL_POST_AGENDAMENTO
        }
    }
}
