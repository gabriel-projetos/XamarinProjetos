using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            //Invocando e passando a instancia de quem está invocando o metodo
            //O argumento do evento é o nome da propriedade que é o Name
            //Que caso name esteja vazio, ele assume o CallerMemberName
            //que é a propriedade que esta chamando o metodo
            //Exemplo: TemMP3Player no caso seria o name
            //Só invoca se a propriedade for diferente de nulo
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));

            //if condi~cional é igual o de cima
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
