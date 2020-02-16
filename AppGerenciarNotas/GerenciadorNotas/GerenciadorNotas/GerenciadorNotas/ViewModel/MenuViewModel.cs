using GerenciadorNotas.Models;
using GerenciadorNotas.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GerenciadorNotas.ViewModel
{
    public class MenuViewModel
    {
        public ICommand MeuCadastroCommand { get; set; }
        public ICommand DadosCursoCommand { get; set; }
        public ICommand NotasFaltasCommand { get; set; }
        public ICommand IntegralizacaoCurricularCommand { get; set; }


        public MenuViewModel()
        {
            TrocaTelaCommand();
        }

        private void TrocaTelaCommand()
        {
            /**********FUTURAMENTE TALVEZ PRECISE PASSAR O USUARIO COMO PARAMETRO *********/
            var meuCadastroView = new MeuCadastroView();
            var dadosCursoView = new DadosCursoView();
            var notasFaltasView = new NotasFaltasView();
            var integralizacaoView = new IntegralizacaoView();

            MeuCadastroCommand = new Command(() =>
            {
                MessagingCenter.Send<MeuCadastroView>(meuCadastroView, "MeuCadastro");
            });

            DadosCursoCommand = new Command(() =>
            {
                MessagingCenter.Send<DadosCursoView>(dadosCursoView, "DadosCurso");

            });

            NotasFaltasCommand = new Command(() => 
            {
                MessagingCenter.Send<NotasFaltasView>(notasFaltasView, "NotasFaltas");
            });

            IntegralizacaoCurricularCommand = new Command(() =>
            {
                MessagingCenter.Send<IntegralizacaoView>(integralizacaoView, "Integralizacao");
            });
        }
    }
}
