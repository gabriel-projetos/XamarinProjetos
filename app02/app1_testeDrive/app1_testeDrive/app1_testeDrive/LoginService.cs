using app1_testeDrive.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace app1_testeDrive
{
    class LoginService
    {
		public async Task FazerLogin(Login login)
		{
			
			//implentação da autenticação
			using (var cliente = new HttpClient())
			{
				//tipo que contem os campos 
				//um array anonimo
				var camposFormulario = new FormUrlEncodedContent(new[]
				{
				//chave e valor <tipo>
				new KeyValuePair<string, string>("email", login.email),
				new KeyValuePair<string, string>("senha", login.senha)
				});

				//endereço base da requisição
				cliente.BaseAddress = new Uri("https://aluracar.herokuapp.com");

				HttpResponseMessage resultado = null;
				try
				{

					//Momento da conexão com o servidor
					//Como segundo argumento é os campos do formulario
					//await pq a execução aguarda a resposta da tarefa
					resultado = await cliente.PostAsync("/login", camposFormulario);
				}
				//Capturando uma execeção
				catch
				{

					MessagingCenter.Send<LoginExeception>(new LoginExeception(@"Ocorreu um erro de comunicação com o servidor.
Por favor verifica a sua conexão e tente novamente."), "FalhaLogin");
				}

			//Verifica o resultado do login
			if (resultado.IsSuccessStatusCode)
				{					
					//Trasforma o conteudo do resultado json em uma string SERILIZAÇÃO
					var conteudoResultado = await resultado.Content.ReadAsStringAsync();

					//DESERELIAZAÇÃO: string em objeto
					//ResultadoLogin vai armazenar a conversão dessa string em objeto
					var resultadoLogin =
						JsonConvert.DeserializeObject<ResultadoLogin>(conteudoResultado);

					//MsgCenter a partir do loginviewmodel vai avisar a classe app.xaml
					//que existe uma nova MainPage que vai ser definida pela aplicação
					//A mensagem será recebida na classe app
					//<Tipo da mensagem: USuario>(Criando um Usuario)
					//Usuario clicou no btão entrar, é enviado a msg de SucessoLogin
					//resultadoLogin.usuario = resultado da conversao stirng json em um objeto c#
					MessagingCenter.Send<Usuario>(resultadoLogin.usuario, "SucessoLogin");
				}
				else
				{
					MessagingCenter.Send<LoginExeception>(new LoginExeception("Usuário ou senha incorretos!"), "FalhaLogin");
				}
			}
	
		}
	}
	public class LoginExeception : Exception
	{
		public LoginExeception(string message) :  base(message)
		{

		}
	}

}
