using app1_testeDrive.Models;
using System;
using System.Collections.Generic;
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



		//Armazena localmente uma instancia do usuario nessa classe
		private readonly Usuario usuario;

		//private set só posso setar essa prop de dentro da classe
		//é necessario instanciar o comando
		public ICommand EditarPerfilCommand { get; private set; }
		public ICommand SalvarCommand { get; private set; }
		public ICommand EditarCommand { get; private set; }

		//Construtor recebendo um usuario como parametro
		public MasterViewModel(Usuario usuario)
		{
			this.usuario = usuario;
			DefinirComandos(usuario);
		}

		private void DefinirComandos(Usuario usuario)
		{
			//recebe uma action, instanciando
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
		}
	}
}
