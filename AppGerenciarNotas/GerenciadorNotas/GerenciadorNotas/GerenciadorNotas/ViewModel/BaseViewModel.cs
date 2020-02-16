using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace GerenciadorNotas.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
		/* INTERFACE PARA IMPLEMENTAR OnPropertyChanged */
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string name = "")
		{
			if (PropertyChanged != null)
				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
