using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModel
{
    public class ShowImageButtonViewModel : INotifyPropertyChanged
    {
        public ICommand MyCommand { get; set; }

        private string statusMessage;
        public string StatusMessage { 
            get 
            {
                return statusMessage;
            } 
            set 
            { 
                if(statusMessage != value)
                {
                    statusMessage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatusMessage)));
                }
            } 
        }

        public ShowImageButtonViewModel()
        {
            MyCommand = new Command((msg) =>
            {
                StatusMessage = "Você ativou o comando";
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
