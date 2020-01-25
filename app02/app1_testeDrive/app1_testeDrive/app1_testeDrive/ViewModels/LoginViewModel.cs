using app1_testeDrive.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

				//implentação da autenticação
				using (var cliente = new HttpClient())
				{
					//tipo que contem os campos 
					//um array anonimo
					var camposFormulario = new FormUrlEncodedContent(new[]
					{
					//chave e valor <tipo>
					new KeyValuePair<string, string>("email", "joao@alura.com.br"),
					new KeyValuePair<string, string>("senha", "alura123")
					});

					//endereço base da requisição
					cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");
					//Como segundo argumento é os campos do formulario
					//await pq a execução aguarda a resposta da tarefa
					await cliente.PostAsync("/login", camposFormulario);

					//MsgCenter a partir do loginviewmodel vai avisar a classe app.xaml
					//que existe uma nova MainPage que vai ser definida pela aplicação
					//A mensagem será recebida na classe app
					//<Tipo da mensagem>(Criando um Usuario)
					//Usuario clicou no btão entrar, é enviado a msg de SucessoLogin
					MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
				}
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
