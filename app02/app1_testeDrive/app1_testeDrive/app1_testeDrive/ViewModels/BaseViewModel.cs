using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace app1_testeDrive.ViewModels
{
    //Abstract pq ngm vai utilizar, e sim vao fazer herança da classe
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        //Notificar a view que uma propriedade foi alterada.
        public event PropertyChangedEventHandler PropertyChanged;


        //Notificar a view que uma propriedade foi alterada.
        //CallerMemberName se n passar nd, ele assume o nameof/Propriedade de quem chamou o metodo
        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            if (PropertyChanged != null)
            {
                //this: quem chama é a propria classe
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
