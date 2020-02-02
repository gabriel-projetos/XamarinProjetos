using app1_testeDrive.Midia;
using app1_testeDrive.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace app1_testeDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
	{

		public string Nome
		{
			get { return this.usuario.nome; }
			set { this.usuario.nome = value; }
		}
		
		public string DataNascimento
		{
			get { return this.usuario.dataNascimento; }
			set { this.usuario.dataNascimento = value; }
		}

		public string Telefone
		{
			//retornar a partir da instancia de usuario retornar/get o dado
			//qnt eu digitar/set na view quero que altere a partir do dado do usuario, o usuario vai receber o dado digitado
			get { return this.usuario.telefone; }
			set { this.usuario.telefone = value; }
		}
		public string Email
		{
			get { return this.usuario.email; }
			set { this.usuario.email = value; }
		}
		private bool editando = false;
		public bool Editando
		{
			get { return editando; }
			//Private set pq a propriedade nao pode ser alterada de fora da classe
			private set 
			{ 
				editando = value;
				//Name no baseviewmodel vai ser recebido com o nome da propriedade ja uqe n foi passado nd
				//no caso Editando será recebido
				OnPropertyChanged();
			}
		}
		
		//binding com a Image em masterview
		private ImageSource fotoPerfil = "perfil.png";

		public ImageSource FotoPerfil
		{
			get { return fotoPerfil; }
			private set 
			{ 
				fotoPerfil = value;

				//Informa a view que teve alteração na tela
				OnPropertyChanged();
			}
		}


		//Armazena localmente uma instancia do usuario nessa classe
		private readonly Usuario usuario;

		//private set só posso setar essa prop de dentro da classe
		//é necessario instanciar o comando
		public ICommand EditarPerfilCommand { get; private set; }
		public ICommand SalvarCommand { get; private set; }
		public ICommand EditarCommand { get; private set; }
		public ICommand TirarFotoCommand { get; private set; }
		public ICommand MeusAgendamentosCommand { get; private set; }
		public ICommand NovoAgendamentoCommand { get; private set; }

		//Construtor recebendo um usuario como parametro
		public MasterViewModel(Usuario usuario)
		{
			this.usuario = usuario;
			DefinirComandos(usuario);
			AssinarMensagens();
		}

		private void AssinarMensagens()
		{
			//array que vem de MainActivity
			MessagingCenter.Subscribe<byte[]>(this, "FotoTirada",
				(bytes) =>
				{
					//Le o array de bytes e converte em um imageSource
					FotoPerfil = ImageSource.FromStream(
						() => new MemoryStream(bytes));
				});
		}

		private void DefinirComandos(Usuario usuario)
		{
			//os comandos recebem uma action no construtor. Instanciamento dos comandos

			EditarPerfilCommand = new Command(() =>
			{
				//Corpo do action/código que sera executado qnd o botao for clicado
				//Tipo da mensagem<Usuario>, Instancia do tipo da mensagem (usuario, Nome da mensagem que sera capturada: "EditarPerfil")
				MessagingCenter.Send<Usuario>(usuario, "EditarPerfil");
			});

			SalvarCommand = new Command(() =>
			{
				this.Editando = false;
				MessagingCenter.Send<Usuario>(usuario, "SucessoSalvarUsuario");
			});

			EditarCommand = new Command(() => 
			{

				//Precisa notificar a view que teve alteração na propriedade
				this.Editando = true;
			});

			//Diz para o MasterView.xaml oq fazer qnd o command/botao for executado
			//Recebe uma action como parametro ((action)) qnd TirarFoto for clicado
			TirarFotoCommand = new Command(() => 
			{
				//Chamar o serviço de dependencia do xamarim
				//para obter a instancia que implementa o ICamera
				//Get: pegar ou obter uma instancia que implementa a interface ICamera<Interface>
				//é necessario registrar a instancia antes de obter
				//vai chamar o metodo no MainActivity no projeto droid
				DependencyService.Get<ICamera>().TirarFoto();
			});

			MeusAgendamentosCommand = new Command(() =>
			{
				//Corpo do action/código que sera executado qnd o botao for clicado
				/*<Objeto que está em anexo na mensagem>
				 * Instancia do objeto em anexo
				 */
				MessagingCenter.Send<Usuario>(usuario, "MeusAgendamentos");
			});

			NovoAgendamentoCommand = new Command(() =>
			{
				MessagingCenter.Send<Usuario>(usuario, "NovoAgendamento");
			});
		}
	}
}
