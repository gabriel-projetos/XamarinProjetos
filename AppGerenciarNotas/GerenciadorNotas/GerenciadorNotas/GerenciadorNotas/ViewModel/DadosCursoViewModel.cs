using GerenciadorNotas.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GerenciadorNotas.ViewModel
{
    public class DadosCursoViewModel
    {
        public string Curso
        {
            get { return this.usuario.Curso; }
            set { this.usuario.Curso = value; }
        }

        public string Unidade
        {
            get { return this.usuario.Unidade; }
            set { this.usuario.Unidade = value; }

        }

        public string Turma
        {
            get { return this.usuario.Turma; }
            set { this.usuario.Turma = value; }
        }
        private readonly Aluno usuario;

    }
}
