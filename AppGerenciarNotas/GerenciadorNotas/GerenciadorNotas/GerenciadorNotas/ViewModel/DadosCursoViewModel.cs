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
            get { return this.usuario.curso; }
            set { this.usuario.curso = value; }
        }

        public string Unidade
        {
            get { return this.usuario.unidade; }
            set { this.usuario.unidade = value; }

        }

        public string Turma
        {
            get { return this.usuario.turma; }
            set { this.usuario.turma = value; }
        }

        private readonly Usuario usuario;

       


    }
}
