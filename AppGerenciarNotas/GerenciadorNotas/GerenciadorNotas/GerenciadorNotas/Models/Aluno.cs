using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorNotas.Models
{
    public class Aluno
    {
        /********* Referente a tela MeuCadastro **************/
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }

        /********* Referente a tela DadosCurso **************/

        public string Curso { get; set; }
        public string Unidade { get; set; }
        public string Turma { get; set; }
    }
}
