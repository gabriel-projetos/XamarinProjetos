using app1_testeDrive.Data;
using app1_testeDrive.Models;
using app1_testeDrive.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace app1_testeDrive.ViewModels
{
    public class AgendamentoViewModel : BaseViewModel
    {                                           
        public Agendamento Agendamento { get; set; }

        public string Modelo
        {
            get { return this.Agendamento.Modelo; }
            set { this.Agendamento.Modelo = value; }
        }

        public decimal Preco
        {
            get { return this.Agendamento.Preco; }
            set { this.Agendamento.Preco = value; }
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

        public AgendamentoViewModel(Veiculo veiculo, Usuario usuario)
        {
            //Construtor
            this.Agendamento = new Agendamento(usuario.nome,
                usuario.telefone, usuario.email, veiculo.Nome, veiculo.Preco);

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
            AgendamentoService agendamentoService = new AgendamentoService();
            await agendamentoService.EnviarAgendamento(this.Agendamento);
        }
    }
}
