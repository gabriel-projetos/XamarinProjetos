using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App.Models
{
    public class ProgressBarPageModel : BaseViewModel
    {
        private double _progress = 0;
        public double Progress { 
            get 
            {
                return _progress;
            }
            set 
            {
                _progress = value;
                OnPropertyChanged();
            } 
        }
        public ICommand CarregarCommand { get; set; }
        public ICommand DescarregarCommand { get; set; }

        public ProgressBarPageModel(Page page)
        {
            CarregarCommand = new Command( /*async*/ () =>
            {
                MessagingCenter.Send<ProgressBarPageModel>(this, "CarregarProgress");
                //if (_progress < 1)
                //{
                //    for (double i = 0; _progress <= 1; i = i + 0.1)
                //    {
                //        Progress = _progress + i;
                //        await Task.Delay(400);                  
                //    };
                //}

                // await page.DisplayAlert("Sucesso", "Carregado com sucesso", "OK");

            });

            DescarregarCommand = new Command(/*async*/ () =>
            {
                MessagingCenter.Send<ProgressBarPageModel>(this, "DescarregarProgress");

                //if (_progress >= 1)
                //{
                //    for (double i = 0; _progress >= 0; i = i + 0.01)
                //    {
                //        Progress = _progress - i;
                //        await Task.Delay(400);

                //    };
                //}

                //Progress =

                /*await*/ //page.DisplayAlert("Sucesso", "Descarregado com sucesso", "OK");

            });
        }

    }
}
