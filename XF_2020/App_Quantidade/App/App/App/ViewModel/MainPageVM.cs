using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModel
{
    public class MainPageVM : INotifyPropertyChanged
    {
        public ICommand Adicionar { get; set; }
        public ICommand Subtrair { get; set; }

        private static int _quantidade = 0;
        public int Quantidade
        {
            get { return _quantidade; }
            set 
            { 
                _quantidade = value;
                OnPropertyChanged(nameof(Quantidade));
            }
        }

        public MainPageVM()
        {
            Adicionar = new Command(param =>
            {
                Quantidade = _quantidade + Convert.ToInt32(param);
            });

            Subtrair = new Command(param =>
            {
                Quantidade = _quantidade + Convert.ToInt32(param);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
