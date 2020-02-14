using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app1_testeDrive.Models;
using System.Windows.Input;
using Xamarin.Forms;

namespace app1_testeDrive.ViewModels
{
    public class DetalheViewModel : BaseViewModel
    {
        public Veiculo Veiculo { get; set; }
        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS);
            }
        }
        public string TextoArCondicionado
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", Veiculo.AR_CONDICIONADO);
            }
        }
        public string TextoMP3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", Veiculo.MP3_PLAYER);
            }
        }
        public bool TemFreioABS
        {
            get
            {
                return Veiculo.TemFreioABS;
            }
            set
            {
                Veiculo.TemFreioABS = value;

                //Houve uma mudança na propriedade do binding
                OnPropertyChanged();

                //Pega o nome de uma prop que existe no sistema
                OnPropertyChanged(nameof(ValorTotal));


            }
        }
        public bool TemArCondicionado
        {
            get
            {
                return Veiculo.TemArCondicionado;
            }
            set
            {
                Veiculo.TemArCondicionado = value;

                //Houve uma mudança na propriedade do binding
                OnPropertyChanged();

                //Pega o nome de uma prop que existe no sistema
                OnPropertyChanged(nameof(ValorTotal));


            }
        }
        public bool TemMP3Player
        {
            get
            {
                return Veiculo.TemMP3Player;
            }
            set
            {
                Veiculo.TemMP3Player = value;

                //Houve uma mudança na propriedade do binding
                OnPropertyChanged();

                //Pega o nome de uma prop que existe no sistema
                OnPropertyChanged(nameof(ValorTotal));


            }
        }
        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }

        //construtor
        public DetalheViewModel(Veiculo veiculo)
        {
            this.Veiculo = veiculo;
            ProximoCommand = new Command(() =>
            {
                //Centro de msg do xamarim
                //veiculo pq é quem está selecionado
                MessagingCenter.Send(veiculo, "Proximo");
            });
        }
        public ICommand ProximoCommand { get; set; }
    }
}
