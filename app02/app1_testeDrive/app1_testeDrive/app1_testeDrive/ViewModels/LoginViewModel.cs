using app1_testeDrive.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace app1_testeDrive.ViewModels
{
    class LoginViewModel
    {
		private string usuario;

		public string Usuario
		{
			get { return usuario; }
			set 
			{ 
				usuario = value;

				//Casting para a classe Command para acessar o metodo ChangeCanExecute	
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
				//Casting para a classe Command para acessar o metodo ChangeCanExecute	
				((Command)EntrarCommand).ChangeCanExecute();
			}
		}

		public ICommand EntrarCommand { get; private set; }

		//Construtor
		public LoginViewModel()
		{
			//Instanciando o command
			//O parametro recebido pelo command é um metodo anoninmo
			//pq uma ACTION é definido no metodo anonimo
			//É disparado qnd o usuario clica no botão
			//Por padrão o botaõ é True ou seja Visivel 
			EntrarCommand = new Command( async () =>
			{
				//Construtor da classe
				var loginService = new LoginService();
				//Chamando fazerlogin de LoginService
				await loginService.FazerLogin(new Login(usuario, senha));
			}, () => 
			{
				//Retorna se o botão ficara habilidade ou desabilitado
				//usuario e senha precisam estar preenchidos
				return !string.IsNullOrEmpty(usuario)
						&& !string.IsNullOrEmpty(senha);
			});
		}	
	}
}
