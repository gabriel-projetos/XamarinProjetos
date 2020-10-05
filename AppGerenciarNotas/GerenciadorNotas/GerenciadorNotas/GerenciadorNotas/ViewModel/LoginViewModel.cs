using GerenciadorNotas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GerenciadorNotas.ViewModel
{
    public class LoginViewModel
    {
		private string ra;

		public string Ra
		{
			get { return ra; }
			set 
			{
				ra = value;
				//Changed pertence ao Command e não ao ICommand por isso precisa converter
				//Informa o botão que houve uma mudança no valor do ra
				((Command)EntrarCommand).ChangeCanExecute();
			}
		}

		private string senha;

		public string Senha
		{
			get { return senha; }
			set 
			{ 
				senha = value;
				//Changed pertence ao Command e não ao ICommand por isso precisa converter
				//Informa o botão que houve uma mudança no valor da senha
				((Command)EntrarCommand).ChangeCanExecute();
			}
		}

		public ICommand EntrarCommand { get; private set; }

		public LoginViewModel()
		{
			EntrarCommand = new Command(() =>
			{
				//Enviando uma mensagem contendo um usuario, para depois verificar a autenticação
				if(ra == "F02AAD1" && senha == "3482")
                {
					MessagingCenter.Send<Aluno>(new Aluno(), "SucessoLogin");
                }
                else
                {
					App.Current.MainPage.DisplayAlert("Falha Login.", "RA ou Senha inválidos, por favor tente novamente.", "OK");
				};

			}, () =>
			{
				//Action do botão que informa se ele pode ser executado ou não,	por padrão é True
				return !string.IsNullOrEmpty(ra)
					&& !string.IsNullOrEmpty(senha);
				
			});
		}
	}
}
