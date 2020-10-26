using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.ViewModel
{
    public class ShowHeaderPageViewModel : INotifyPropertyChanged
    {
        public ICommand BackButton { get; set; }
        public ICommand MenuAuxiliar { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ShowHeaderPageViewModel()
        {
            BackButton = new Command((parameter) =>
            {
                if(parameter != null)
                {
                    Application.Current.MainPage.DisplayAlert("oK", "Botão clicado - Parametro: " + parameter.ToString(), "Continue");
                }
                else
                {
                    //Application.Current.MainPage.DisplayAlert("oK", "BackButton", "Continue");
                    MessagingCenter.Send<string>("Teste", "Voltar");
                }
                
            });

            MenuAuxiliar = new Command((parameter) =>
            {
                if (parameter != null)
                {
                    Application.Current.MainPage.DisplayAlert("oK", "Botão clicado - Parametro: " + parameter.ToString(), "Continue");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("oK", "Menu Auxiliar ", "Continue");
                }

            });
        }
    }
}
